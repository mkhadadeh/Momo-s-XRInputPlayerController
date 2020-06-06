using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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
    public float stickDeadzone = 0.3f;
    public float termVel = 0f;
    Vector3 fProj;
    Vector3 rProj;
    float velocityY;
    bool rotateFlicked;
    public float rotationAngle = 30;
    float currentSelectedRotation;
    public ControlValues controlValues;

    public XRLaserPointer xrLaserPointer;
    public float buttonFloatSensitivity = 0.3f;
    public List<ButtonInteractors> buttonInteractors;

    public bool teleport;
    public List<ButtonInteractors> teleportInteractors;
    public LayerMask teleportMask;

    Dictionary<ButtonInteractors, bool> buttonInteractorStates; // For each interactor, the bool shows whether it was pressed
    Dictionary<ButtonInteractors, bool> teleportInteractorStates; // For each interactor, the bool shows whether it was pressed

    public struct ControlValues
    {
        public Vector3 headPos;
        public Vector3 rightHandPos;
        public Vector3 leftHandPos;
        public Quaternion headRot;
        public Quaternion rightHandRot;
        public Quaternion leftHandRot;
        public Vector2 leftHandJoystick;
        public Vector2 rightHandJoystick;
        public float leftHandTrigger;
        public float rightHandTrigger;
        public float leftHandGrip;
        public float rightHandGrip;
        public bool leftHandButtonPrimary;
        public bool leftHandButtonSecondary;
        public bool rightHandButtonPrimary;
        public bool rightHandButtonSecondary;
        public bool menuButton;
        public bool leftHandJoystickPressed;
        public bool rightHandJoystickPressed;
    }

    void Start() {
        velocityY = 0;
        rotateFlicked = false;
        currentSelectedRotation = 0;

        // Initialize all to false
        buttonInteractorStates = new Dictionary<ButtonInteractors, bool>();
        teleportInteractorStates = new Dictionary<ButtonInteractors, bool>();
        for (int i = 0; i < 9; i++)
        {
            buttonInteractorStates[(ButtonInteractors)i] = false;
            teleportInteractorStates[(ButtonInteractors)i] = false;
        }
    }

    void Update()
    {
        PollProcessor();
        // Calculate forward and right vectors
        if(moveRelativeToFacing) {
            fProj = Vector3.Normalize(Vector3.Scale(mainCamera.transform.forward, new Vector3(1,0,1)));
        }
        else {
            fProj = Quaternion.Euler(0, currentSelectedRotation, 0) * new Vector3(0,0,1);
        }
        rProj = Vector3.Normalize(Vector3.Cross(new Vector3(0,1,0),fProj));

        // Debug.DrawRay(mainCamera.transform.position, fProj * 20,Color.red);
        // Debug.DrawRay(mainCamera.transform.position, rProj * 20,Color.blue);

        if (controlsRotate)
        {
            // Preprocess input data
            Vector2 rawStickData = controlValues.rightHandJoystick;
            // Create stick deadzone
            if (Mathf.Abs(rawStickData.x) <= stickDeadzone)
            {
                rawStickData.x = 0;
            }
            if (!rotateFlicked && rawStickData.x != 0)
            {
                int direction = (int)Mathf.Sign(rawStickData.x); //-1 = left. 1 = right.
                mainCamera.transform.parent.RotateAround(mainCamera.transform.position, Vector3.up, rotationAngle * direction);
                currentSelectedRotation += rotationAngle * direction;
                rotateFlicked = true;
            }
            if (rawStickData.magnitude < stickDeadzone)
            {
                rotateFlicked = false;
            }
        }
        if (controlsMove || doGravityWithoutMove)
        {
            // Preprocess input data
            Vector2 rawStickData = controlValues.leftHandJoystick;
            // Create stick dead zone
            if (Mathf.Abs(rawStickData.x) <= stickDeadzone)
            {
                rawStickData.x = 0;
            }
            if (Mathf.Abs(rawStickData.y) <= stickDeadzone)
            {
                rawStickData.y = 0;
            }
            Vector3 moveData = moveSpeed * Vector3.Normalize(fProj * rawStickData.y + rProj * rawStickData.x);
            velocityY += gravity * Time.deltaTime;
            if (velocityY < termVel && termVel != 0)
            {
                velocityY = termVel;
            }
            if (controller.isGrounded)
            {
                velocityY = -0.1f;
            }

            if (!controlsMove)
            {
                moveData = Vector3.zero;
            }

            moveData.y = velocityY;
            controller.Move(moveData * Time.deltaTime);
        }

        if (pressXRButtons && xrLaserPointer != null && xrLaserPointer.enabled)
        {
            xrLaserPointer.interactWithXRButtons = pressXRButtons;
            bool buttonPressed = false;
            bool buttonReleased = false;
            foreach(var interactor in buttonInteractors)
            {
                UpdateInteractionsMap(interactor, ref buttonInteractorStates, ref buttonPressed, ref buttonReleased);
            }
            if (buttonPressed)
            {
                // Send button press if currently hovering over button
                xrLaserPointer.PressXRButton();
            }
            if(buttonReleased)
            {
                // Send button released if currently hovering over button
                xrLaserPointer.ReleaseXRButton();
            }
        }
        if (teleport && xrLaserPointer != null && xrLaserPointer.enabled)
        {
            bool buttonPressed = false;
            bool buttonReleased = false;
            foreach (var interactor in teleportInteractors)
            {
                UpdateInteractionsMap(interactor, ref teleportInteractorStates, ref buttonPressed, ref buttonReleased);
            }
            if (buttonReleased)
            {
                RaycastHit hit;
                if(xrLaserPointer.getRaycastHit(out hit))
                {
                    if (teleportMask == (teleportMask | (1 << hit.collider.gameObject.layer))) // If collider is in the layermask, we can teleport to it
                    {
                        controller.Move(hit.point - this.transform.position + new Vector3(0, controller.height/(float)2, 0));
                    }
                }
            }
        }
    }

    public void SendHaptics(bool leftHand, float amplitude, float duration)
    {
        UnityEngine.XR.HapticCapabilities capabilities;
        foreach (var device in XRProcessor.devices)
        {
            if(device.Key == UnityEngine.XR.XRNode.LeftHand && device.Value.Count != 0 && leftHand)
            {
                // Send haptics to left hand
                if(device.Value[0].TryGetHapticCapabilities(out capabilities))
                {
                    if(capabilities.supportsImpulse)
                    {
                        device.Value[0].SendHapticImpulse(0, amplitude, duration);
                    }
                }
                break;
            }
            else if (device.Key == UnityEngine.XR.XRNode.RightHand && device.Value.Count != 0 && !leftHand)
            {
                // Send haptics to right hand
                if (device.Value[0].TryGetHapticCapabilities(out capabilities))
                {
                    if (capabilities.supportsImpulse)
                    {
                        device.Value[0].SendHapticImpulse(0, amplitude, duration);
                    }
                }
                break;
            }
        }
    }
    
    void PollProcessor()
    {
        XRProcessor.PollFeature(UnityEngine.XR.XRNode.Head, Feature.DEVICE_POSITION_VECTOR3, out controlValues.headPos);
        XRProcessor.PollFeature(UnityEngine.XR.XRNode.Head, Feature.DEVICE_ROTATION_QUATERNION, out controlValues.headRot);
        XRProcessor.PollFeature(UnityEngine.XR.XRNode.LeftHand, Feature.PRIMARY_BUTTON_BOOL, out controlValues.leftHandButtonPrimary);
        XRProcessor.PollFeature(UnityEngine.XR.XRNode.LeftHand, Feature.SECONDARY_BUTTON_BOOL, out controlValues.leftHandButtonSecondary);
        XRProcessor.PollFeature(UnityEngine.XR.XRNode.LeftHand, Feature.GRIP_FLOAT, out controlValues.leftHandGrip);
        XRProcessor.PollFeature(UnityEngine.XR.XRNode.LeftHand, Feature.PRIMARY_2D_AXIS_VECTOR2, out controlValues.leftHandJoystick);
        XRProcessor.PollFeature(UnityEngine.XR.XRNode.LeftHand, Feature.PRIMARY_2D_AXIS_CLICK_BOOL, out controlValues.leftHandJoystickPressed);
        XRProcessor.PollFeature(UnityEngine.XR.XRNode.LeftHand, Feature.DEVICE_POSITION_VECTOR3, out controlValues.leftHandPos);
        XRProcessor.PollFeature(UnityEngine.XR.XRNode.LeftHand, Feature.DEVICE_ROTATION_QUATERNION, out controlValues.leftHandRot);
        XRProcessor.PollFeature(UnityEngine.XR.XRNode.LeftHand, Feature.TRIGGER_FLOAT, out controlValues.leftHandTrigger);
        XRProcessor.PollFeature(UnityEngine.XR.XRNode.LeftHand, Feature.MENU_BUTTON_BOOL, out controlValues.menuButton);
        XRProcessor.PollFeature(UnityEngine.XR.XRNode.RightHand, Feature.PRIMARY_BUTTON_BOOL, out controlValues.rightHandButtonPrimary);
        XRProcessor.PollFeature(UnityEngine.XR.XRNode.RightHand, Feature.SECONDARY_BUTTON_BOOL, out controlValues.rightHandButtonSecondary);
        XRProcessor.PollFeature(UnityEngine.XR.XRNode.RightHand, Feature.GRIP_FLOAT, out controlValues.rightHandGrip);
        XRProcessor.PollFeature(UnityEngine.XR.XRNode.RightHand, Feature.PRIMARY_2D_AXIS_VECTOR2, out controlValues.rightHandJoystick);
        XRProcessor.PollFeature(UnityEngine.XR.XRNode.RightHand, Feature.PRIMARY_2D_AXIS_CLICK_BOOL, out controlValues.rightHandJoystickPressed);
        XRProcessor.PollFeature(UnityEngine.XR.XRNode.RightHand, Feature.DEVICE_POSITION_VECTOR3, out controlValues.rightHandPos);
        XRProcessor.PollFeature(UnityEngine.XR.XRNode.RightHand, Feature.DEVICE_ROTATION_QUATERNION, out controlValues.rightHandRot);
        XRProcessor.PollFeature(UnityEngine.XR.XRNode.RightHand, Feature.TRIGGER_FLOAT, out controlValues.rightHandTrigger);
    }

    private void UpdateInteractionsMap(ButtonInteractors interactor, ref Dictionary<ButtonInteractors, bool> interactorMap, ref bool buttonPressed, ref bool buttonReleased)
    {
        // Some cursed shit right here. Look away
        switch (interactor)
        {
            case ButtonInteractors.LeftGrip:
                if (controlValues.leftHandGrip >= buttonFloatSensitivity && !interactorMap[interactor])
                {
                    interactorMap[interactor] = true;
                    buttonPressed = true;
                }
                else if (controlValues.leftHandGrip < buttonFloatSensitivity && interactorMap[interactor])
                {
                    interactorMap[interactor] = false;
                    buttonReleased = true;
                }
                break;
            case ButtonInteractors.LeftPrimary:
                if (controlValues.leftHandButtonPrimary && !interactorMap[interactor])
                {
                    interactorMap[interactor] = true;
                    buttonPressed = true;
                }
                else if (!controlValues.leftHandButtonPrimary && interactorMap[interactor])
                {
                    interactorMap[interactor] = false;
                    buttonReleased = true;
                }
                break;
            case ButtonInteractors.LeftSecondary:
                if (controlValues.leftHandButtonSecondary && !interactorMap[interactor])
                {
                    interactorMap[interactor] = true;
                    buttonPressed = true;
                }
                else if (!controlValues.leftHandButtonSecondary && interactorMap[interactor])
                {
                    interactorMap[interactor] = false;
                    buttonReleased = true;
                }
                break;
            case ButtonInteractors.LeftTrigger:
                if (controlValues.leftHandTrigger >= buttonFloatSensitivity && !interactorMap[interactor])
                {
                    interactorMap[interactor] = true;
                    buttonPressed = true;
                }
                else if (controlValues.leftHandTrigger < buttonFloatSensitivity && interactorMap[interactor])
                {
                    interactorMap[interactor] = false;
                    buttonReleased = true;
                }
                break;
            case ButtonInteractors.Menu:
                if (controlValues.menuButton && !interactorMap[interactor])
                {
                    interactorMap[interactor] = true;
                    buttonPressed = true;
                }
                else if (!controlValues.menuButton && interactorMap[interactor])
                {
                    interactorMap[interactor] = false;
                    buttonReleased = true;
                }
                break;
            case ButtonInteractors.RightGrip:
                if (controlValues.rightHandGrip >= buttonFloatSensitivity && !interactorMap[interactor])
                {
                    interactorMap[interactor] = true;
                    buttonPressed = true;
                }
                else if (controlValues.rightHandGrip < buttonFloatSensitivity && interactorMap[interactor])
                {
                    interactorMap[interactor] = false;
                    buttonReleased = true;
                }
                break;
            case ButtonInteractors.RightPrimary:
                if (controlValues.rightHandButtonPrimary && !interactorMap[interactor])
                {
                    interactorMap[interactor] = true;
                    buttonPressed = true;
                }
                else if (!controlValues.rightHandButtonPrimary && interactorMap[interactor])
                {
                    interactorMap[interactor] = false;
                    buttonReleased = true;
                }
                break;
            case ButtonInteractors.RightSecondary:
                if (controlValues.rightHandButtonSecondary && !interactorMap[interactor])
                {
                    interactorMap[interactor] = true;
                    buttonPressed = true;
                }
                else if (!controlValues.rightHandButtonSecondary && interactorMap[interactor])
                {
                    interactorMap[interactor] = false;
                    buttonReleased = true;
                }
                break;
            case ButtonInteractors.RightTrigger:
                if (controlValues.rightHandTrigger >= buttonFloatSensitivity && !interactorMap[interactor])
                {
                    interactorMap[interactor] = true;
                    buttonPressed = true;
                }
                else if (controlValues.rightHandTrigger < buttonFloatSensitivity && interactorMap[interactor])
                {
                    interactorMap[interactor] = false;
                    buttonReleased = true;
                }
                break;
        }
    }
}

public enum ButtonInteractors
{
    LeftPrimary, LeftSecondary, RightPrimary, RightSecondary, Menu, LeftGrip, LeftTrigger, RightGrip, RightTrigger
};