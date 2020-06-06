using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(XRPlayerController))]
public class XRPlayerControllerEditor : Editor
{
    private ReorderableList buttonInteractorsList;
    private ReorderableList teleportInteractorsList;
    private void OnEnable()
    {
        buttonInteractorsList = new ReorderableList(serializedObject, serializedObject.FindProperty("buttonInteractors"), true, true, true, true);
        buttonInteractorsList.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
        {
            var element = buttonInteractorsList.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += 2;
            EditorGUI.PropertyField(new Rect(rect.x, rect.y, 200, EditorGUIUtility.singleLineHeight), element, GUIContent.none);
        };
        buttonInteractorsList.drawHeaderCallback = (Rect rect) =>
        {
            EditorGUI.LabelField(rect, "These Interactions Will Trigger XR Buttons");
        };

        teleportInteractorsList = new ReorderableList(serializedObject, serializedObject.FindProperty("teleportInteractors"), true, true, true, true);
        teleportInteractorsList.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
        {
            var element = teleportInteractorsList.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += 2;
            EditorGUI.PropertyField(new Rect(rect.x, rect.y, 200, EditorGUIUtility.singleLineHeight), element, GUIContent.none);
        };
        teleportInteractorsList.drawHeaderCallback = (Rect rect) =>
        {
            EditorGUI.LabelField(rect, "These Interactions Will Trigger Teleportation");
        };
    }
    public override void OnInspectorGUI()
    {
        var xrPlayerController = target as XRPlayerController;

        var controlsMoveProperty = serializedObject.FindProperty("controlsMove");
        var controlsRotateProperty = serializedObject.FindProperty("controlsRotate");
        var moveRelativeToFacingProperty = serializedObject.FindProperty("moveRelativeToFacing");
        var pressXRButtonsProperty = serializedObject.FindProperty("pressXRButtons");
        var controllerProperty = serializedObject.FindProperty("controller");
        var mainCameraProperty = serializedObject.FindProperty("mainCamera");
        var gravityProperty = serializedObject.FindProperty("gravity");
        var moveSpeedProperty = serializedObject.FindProperty("moveSpeed");
        var stickDeadzoneProperty = serializedObject.FindProperty("stickDeadzone");
        var termVelProperty = serializedObject.FindProperty("termVel");
        var rotationAngleProperty = serializedObject.FindProperty("rotationAngle");
        var xrLaserPointerProperty = serializedObject.FindProperty("xrLaserPointer");
        var buttonFloatSensitivityProperty = serializedObject.FindProperty("buttonFloatSensitivity");
        var teleportProperty = serializedObject.FindProperty("teleport");
        var teleportMaskProperty = serializedObject.FindProperty("teleportMask");
        var doGravityWithoutMoveProperty = serializedObject.FindProperty("doGravityWithoutMove");

        serializedObject.Update();
        
        EditorGUILayout.PropertyField(controllerProperty, new GUIContent("Controller", "The Character Controller that allows Movement"));
        EditorGUILayout.PropertyField(mainCameraProperty, new GUIContent("Main Camera", "This is the player's HMD Camera"));

        EditorGUILayout.PropertyField(controlsMoveProperty, new GUIContent("Controls Move", "Whether or not the player can move with the left thumbstick"));
        
        if(!xrPlayerController.controlsMove)
        {
            EditorGUILayout.PropertyField(doGravityWithoutMoveProperty, new GUIContent("Do Gravity Without Move", "Allows the controller to still process gravity without movement input being allowed"));
        }

        EditorGUILayout.PropertyField(controlsRotateProperty, new GUIContent("Controls Rotate", "Whether or not the player can rotate with the right thumbstick"));

        if (xrPlayerController.controlsMove)
        {
            EditorGUILayout.PropertyField(moveRelativeToFacingProperty, new GUIContent("Move Relative To Facing", "When checked, the direction the player is facing will always be the front direction that motion will derive from"));
            EditorGUILayout.PropertyField(gravityProperty, new GUIContent("Gravity", "This value will be added onto the y velocity every second"));
            EditorGUILayout.PropertyField(moveSpeedProperty, new GUIContent("Move Speed", "The player's horizontal movement speed"));
            EditorGUILayout.PropertyField(termVelProperty, new GUIContent("Term Vel", "Terminal Velocity. Set to 0 if you don't want terminal velocity."));
        }
        if(xrPlayerController.controlsRotate)
        {
            EditorGUILayout.PropertyField(rotationAngleProperty, new GUIContent("Rotation Angle", "How many degrees the player will turn for every flick of the right thumbstick"));
        }

        if (xrPlayerController.controlsMove || xrPlayerController.controlsRotate)
        {
            EditorGUILayout.PropertyField(stickDeadzoneProperty, new GUIContent("Stick Deadzone", "Thumbstick values below this will be set to 0"));
        }

        EditorGUILayout.PropertyField(pressXRButtonsProperty, new GUIContent("Press XR Buttons", "Whether or not the player can interact with XR Buttons"));
        EditorGUILayout.PropertyField(teleportProperty, new GUIContent("Teleport", "Allow teleportation"));
        if(xrPlayerController.pressXRButtons || xrPlayerController.teleport)
        {
            EditorGUILayout.PropertyField(buttonFloatSensitivityProperty, new GUIContent("Button Float Sensitivity", "If the trigger's/grip's value is less than this, it will not be considered pressed"));
            EditorGUILayout.PropertyField(xrLaserPointerProperty, new GUIContent("XR Laser Pointer", "The XR Laser Pointer object that will trigger the buttons"));
        }

        if (xrPlayerController.pressXRButtons)
        {
            buttonInteractorsList.DoLayoutList();
        }
        if(xrPlayerController.teleport)
        {
            EditorGUILayout.PropertyField(teleportMaskProperty, new GUIContent("Teleport Mask", "Layer mask for any collider that can be teleported to"));
            teleportInteractorsList.DoLayoutList();
        }

        serializedObject.ApplyModifiedProperties();
    }
}