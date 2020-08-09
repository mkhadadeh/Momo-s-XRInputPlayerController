// XR Player Controller Script
// © Mohammed Khadadeh 2020

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.InputSystem;

public class XRPlayerController : MonoBehaviour
{
    public bool controlsMove = true;
    public bool doGravityWithoutMove;
    public bool controlsRotate = true;
    public bool moveRelativeToFacing;
    public bool pressXRButtons = true;
    
    public CharacterController controller;
    public Camera mainCamera;
    public float gravity = -9.81f;
    public float moveSpeed = 2;
    public float termVel = 0f;
    public float heightPadding = 0.05f;

    Vector3 fProj;
    Vector3 rProj;
    Vector3 fDir;
    Vector3 rDir;
    float velocityY;

    Vector3 lateralMoveData;
    RaycastHit groundHit;

    bool rotateFlicked;
    public float rotationAngle = 30;
    float currentSelectedRotation;

    public XRInputActions inputActions;

    float hapticTimer;
    bool left;

    public XRLaserPointer xrLaserPointer;
    public float buttonFloatSensitivity = 0.3f;

    public bool teleport;
    public LayerMask teleportMask;
    public LayerMask groundMask;

    void Start() {
        velocityY = 0;
        rotateFlicked = false;
        currentSelectedRotation = 0;
    }

    void Update()
    {
        // Calculate forward and right vectors
        if (moveRelativeToFacing) {
            fProj = Vector3.Normalize(Vector3.Scale(mainCamera.transform.forward, new Vector3(1,0,1)));
        }
        else {
            fProj = Quaternion.Euler(0, currentSelectedRotation, 0) * new Vector3(0,0,1);
        }
        rProj = Vector3.Normalize(Vector3.Cross(new Vector3(0,1,0),fProj));
        if(Physics.Raycast(transform.position, -Vector3.up, out groundHit, controller.height + heightPadding, groundMask))
        {
            Debug.DrawLine(groundHit.point, groundHit.point + groundHit.normal * 4, Color.gray);
            fDir = Vector3.Cross(groundHit.normal, -rProj);
            rDir = Vector3.Cross(groundHit.normal, fProj);
        }
        else
        {
            fDir = fProj;
            rDir = rProj;
        }
        
        //Debug.DrawLine(transform.position, transform.position - (Vector3.up * (controller.height + heightPadding)),Color.green);

        if (controlsMove)
        {
            // Preprocess input data
            Vector2 rawStickData = inputActions.XRPlayerController.Move.ReadValue<Vector2>();
            // Create stick dead zone
            lateralMoveData = moveSpeed * Vector3.Normalize(fDir * rawStickData.y + rDir * rawStickData.x);
        }
        else
        {
            lateralMoveData = Vector3.zero;
        }

        //Debug.DrawRay(mainCamera.transform.position, fDir * 20,Color.red);
        //Debug.DrawRay(mainCamera.transform.position, rDir * 20,Color.blue);


        // TODO: Make Character Controller Move down slopes naturally rather than stagger
        if (doGravityWithoutMove || controlsMove)
        {
            velocityY += gravity * Time.deltaTime;
            if (velocityY < termVel && termVel != 0)
            {
                velocityY = termVel;
            }

            if (controller.isGrounded && lateralMoveData.y <= 0)
            {
                velocityY = -0.1f;
            }
        }
        controller.Move(new Vector3(lateralMoveData.x, lateralMoveData.y + velocityY, lateralMoveData.z) * Time.deltaTime);

    }

    public void SendHaptics(bool leftHand, float amplitude, float duration)
    {
        UnityEngine.XR.HapticCapabilities capabilities;
        var inputDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(leftHand ? UnityEngine.XR.XRNode.LeftHand : UnityEngine.XR.XRNode.RightHand, inputDevices);
        if(inputDevices[0].TryGetHapticCapabilities(out capabilities))
        {
            if (capabilities.supportsImpulse)
            {
                inputDevices[0].SendHapticImpulse(0, amplitude, duration);
            }
        }
    }

    private void OnEnable()
    {
        if(inputActions == null)
        {
            inputActions = new XRInputActions();
        }
        inputActions.Enable();
        inputActions.XRPlayerController.Teleport.canceled += context => Teleport(context);
        inputActions.XRPlayerController.Interact.performed += context => Interact(context);
        inputActions.XRPlayerController.Interact.canceled += context => EndInteraction(context);
        inputActions.XRPlayerController.RotateCamera.performed += context => ProcessXRRotate(context);
    }


    private void OnDisable()
    {
        inputActions.XRPlayerController.Teleport.canceled -= context => Teleport(context);
        inputActions.XRPlayerController.Interact.performed -= context => Interact(context);
        inputActions.XRPlayerController.Interact.canceled -= context => EndInteraction(context);
        inputActions.XRPlayerController.RotateCamera.performed += context => ProcessXRRotate(context);
        inputActions.Disable();
    }

    void Teleport(InputAction.CallbackContext ctx)
    {
        if (teleport && xrLaserPointer != null && xrLaserPointer.enabled)
        {
            RaycastHit hit;
            if (xrLaserPointer.getRaycastHit(out hit))
            {
                if (teleportMask == (teleportMask | (1 << hit.collider.gameObject.layer))) // If collider is in the layermask, we can teleport to it
                {
                    controller.Move(hit.point - this.transform.position + new Vector3(0, controller.height / (float)2, 0));
                }
            }
        }

    }

    void Interact(InputAction.CallbackContext ctx)
    {
        if (pressXRButtons && xrLaserPointer != null && xrLaserPointer.enabled)
        {
            xrLaserPointer.PressXRButton();
        }
    }

    void EndInteraction(InputAction.CallbackContext ctx)
    {
        
        if (pressXRButtons && xrLaserPointer != null && xrLaserPointer.enabled)
        {
            xrLaserPointer.ReleaseXRButton();
        }
    }

    void ProcessXRRotate(InputAction.CallbackContext ctx)
    {
        if (controlsRotate)
        {
            // Preprocess input data
            Vector2 rawStickData = inputActions.XRPlayerController.RotateCamera.ReadValue<Vector2>();
            if (!rotateFlicked && rawStickData.x != 0)
            {
                int direction = (int)Mathf.Sign(rawStickData.x); //-1 = left. 1 = right.
                mainCamera.transform.parent.RotateAround(mainCamera.transform.position, Vector3.up, rotationAngle * direction);
                currentSelectedRotation += rotationAngle * direction;
                rotateFlicked = true;
            }
            if (rawStickData.magnitude == 0)
            {
                rotateFlicked = false;
            }
        }
    }

}
