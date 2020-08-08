using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRAvatar : MonoBehaviour
{
    public XRPlayerController playerController;

    public Transform head;
    public Transform rightHand;
    public Transform leftHand;

    void Update()
    {
        head.localPosition = playerController.inputActions.XRAvatar.HeadPosition.ReadValue<Vector3>();
        head.localRotation = playerController.inputActions.XRAvatar.HeadRotation.ReadValue<Quaternion>();
        rightHand.localPosition = playerController.inputActions.XRAvatar.RightHandPosition.ReadValue<Vector3>();
        rightHand.localRotation = playerController.inputActions.XRAvatar.RightHandRotation.ReadValue<Quaternion>();
        leftHand.localPosition = playerController.inputActions.XRAvatar.LeftHandPosition.ReadValue<Vector3>();
        leftHand.localRotation = playerController.inputActions.XRAvatar.LeftHandRotation.ReadValue<Quaternion>();
    }
}
