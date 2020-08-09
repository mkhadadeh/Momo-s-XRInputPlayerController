using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController8D : MonoBehaviour
{
    public float velocity = 5;
    public float turnSpeed = 10;
    public float height = 0.5f;
    public float heightPadding = 0.05f;
    public LayerMask ground;
    public float maxGroundAngle = 120;
    public bool debug;

    Vector2 input;
    float angle;
    float groundAngle;

    Quaternion targetRotation;
    Transform cam;

    XRInputActions inputActions;

    Vector3 forward;
    RaycastHit hitInfo;
    bool grounded;

    private void Start()
    {
        cam = Camera.main.transform;
    }

    private void Awake()
    {
        inputActions = new XRInputActions();
    }

    private void Update()
    {
        GetInput();
        CalculateDirection();
        CalculateForward();
        CalculateGroundAngle();
        CheckGround();
        ApplyGravity();
        DrawDebugLines();

        if (!(Mathf.Abs(input.x) == 0 && Mathf.Abs(input.y) == 0))
        {
            Rotate();
            Move();
        }
    }

    void GetInput()
    {
        input = inputActions.XRPlayerController.Move.ReadValue<Vector2>();
    }

    void CalculateDirection()
    {
        angle = Mathf.Atan2(input.x, input.y);
        angle *= Mathf.Rad2Deg;
        angle += cam.eulerAngles.y;
    }

    void Rotate()
    {
        targetRotation = Quaternion.Euler(0, angle, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }

    void Move()
    {
        if (groundAngle <= maxGroundAngle)
        {
            transform.position += forward * velocity * Time.deltaTime;
        }
    }

    void CalculateForward()
    {
        if(!grounded)
        {
            forward = transform.forward;
        }
        else
        {
            forward = Vector3.Cross(hitInfo.normal, -transform.right);
        }
    }

    void CalculateGroundAngle()
    {
        if(!grounded)
        {
            groundAngle = 90;
        }
        else
        {
            Vector3.Angle(hitInfo.normal, transform.forward);
        }
    }
    
    void CheckGround()
    {
        if(Physics.Raycast(transform.position, -Vector3.up, out hitInfo, height + heightPadding, ground)) {
            if(Vector3.Distance(transform.position, hitInfo.point) < height)
            {
                transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.up * height, 5 * Time.deltaTime);
            }
            grounded = true;
        }
        else {
            grounded = false;
        }
    }

    void ApplyGravity()
    {
        if(!grounded)
        {
            transform.position += Physics.gravity * Time.deltaTime;
        }
    }

    void DrawDebugLines()
    {
        if(debug)
        {
            Debug.DrawLine(transform.position, transform.position + forward * 20, Color.blue);
            Debug.DrawLine(transform.position, transform.position - Vector3.up * height, Color.green);
        }
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }
}
