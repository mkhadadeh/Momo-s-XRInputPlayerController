using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController8D : MonoBehaviour
{
    public Transform target;
    public Vector3 offsetPos;
    public float moveSpeed = 5;
    public float turnSpeed = 10;
    public float smoothSpeed = 0.5f;

    Quaternion targetRotation;
    Vector3 targetPos;
    bool smoothRotation = false;

    XRInputActions inputActions;

    private void Awake()
    {
        inputActions = new XRInputActions();
        inputActions.Blah.Blah1.performed += ctx => { if (!smoothRotation) StartCoroutine("RotateAroundTarget", 45); };
        inputActions.Blah.Blah2.performed += ctx => { if (!smoothRotation) StartCoroutine("RotateAroundTarget", -45); };
    }

    private void Update()
    {
        MoveWithTarget();
        LookAtTarget();

        
    }

    void MoveWithTarget()
    {
        targetPos = target.position + offsetPos;
        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }

    void LookAtTarget()
    {
        targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }

    IEnumerator RotateAroundTarget(float angle)
    {
        Vector3 vel = Vector3.zero;
        Vector3 targetOffsetPos = Quaternion.Euler(0, angle, 0) * offsetPos;
        float dist = Vector3.Distance(offsetPos, targetOffsetPos);
        smoothRotation = true;

        while (dist > 0.02f)
        {
            offsetPos = Vector3.SmoothDamp(offsetPos, targetOffsetPos, ref vel, smoothSpeed);
            dist = Vector3.Distance(offsetPos, targetOffsetPos);
            yield return null;
        }

        smoothRotation = false;
        offsetPos = targetOffsetPos;
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
