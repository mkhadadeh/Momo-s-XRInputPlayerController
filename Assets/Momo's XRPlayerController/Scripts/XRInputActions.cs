// GENERATED AUTOMATICALLY FROM 'Assets/Momo's XRPlayerController/Scripts/XRInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @XRInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @XRInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""XRInputActions"",
    ""maps"": [
        {
            ""name"": ""XRPlayerController"",
            ""id"": ""b184b9d8-f2c5-48c2-b004-951e59670ad3"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""0f2a5884-f483-4488-a9dc-406f6cd1fead"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate Camera"",
                    ""type"": ""Value"",
                    ""id"": ""b7552904-a3e4-46d6-be56-d45bfdba4c99"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Teleport"",
                    ""type"": ""Button"",
                    ""id"": ""89657686-d0b0-4c0c-a8bd-35d8e389e628"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""147fce46-7af8-4251-8a29-edc6a3607b2b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6c58babc-8346-44fd-a263-013ba2be3acd"",
                    ""path"": ""<XRController>{LeftHand}/joystick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""XR Controller"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6b69dad4-17bc-42e8-90a1-e754ecb60e30"",
                    ""path"": ""<XRController>{RightHand}/joystick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""XR Controller"",
                    ""action"": ""Rotate Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d298c3a0-6ff3-4534-a2ec-bf8eb27ab404"",
                    ""path"": ""<XRController>{LeftHand}/gripPressed"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone"",
                    ""groups"": ""XR Controller"",
                    ""action"": ""Teleport"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""27ffcec6-398b-4fcf-ad17-4caa90e98c18"",
                    ""path"": ""<XRController>{RightHand}/gripPressed"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone"",
                    ""groups"": ""XR Controller"",
                    ""action"": ""Teleport"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6ac066e2-2f0b-4b41-9494-780c80d77db8"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse And Keyboard"",
                    ""action"": ""Teleport"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e100d2c4-cdbb-4868-b7bf-1467cb98efa2"",
                    ""path"": ""<XRController>{LeftHand}/triggerPressed"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone"",
                    ""groups"": ""XR Controller"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""380fc0a6-b14c-4b26-87a3-b235e579e2b3"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse And Keyboard"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ffb39217-a8ec-43fb-91ce-ec7f7d53527a"",
                    ""path"": ""<XRController>{RightHand}/triggerPressed"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone"",
                    ""groups"": ""XR Controller"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""XRAvatar"",
            ""id"": ""2b68df80-9ba8-4647-8f71-43e01c813b6a"",
            ""actions"": [
                {
                    ""name"": ""HeadPosition"",
                    ""type"": ""Value"",
                    ""id"": ""71a60397-ced9-4cec-8aa8-317db317651e"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""HeadRotation"",
                    ""type"": ""Value"",
                    ""id"": ""6295540b-9c0e-4196-8b98-c0b19dd91bd9"",
                    ""expectedControlType"": ""Quaternion"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftHandPosition"",
                    ""type"": ""Value"",
                    ""id"": ""6ae2193e-fade-459b-bcb9-a5480a2d0064"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftHandRotation"",
                    ""type"": ""Value"",
                    ""id"": ""ecc2688e-0cb3-4c23-bfd4-0a6cd80b036b"",
                    ""expectedControlType"": ""Quaternion"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightHandPosition"",
                    ""type"": ""Value"",
                    ""id"": ""4445c19f-03ae-4df6-b498-5a56febffe43"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightHandRotation"",
                    ""type"": ""Value"",
                    ""id"": ""2cc67f94-d411-4137-a860-efb3cc94220b"",
                    ""expectedControlType"": ""Quaternion"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b337c8f3-0add-4579-b20d-176759a7918e"",
                    ""path"": ""<XRHMD>/devicePosition"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HeadPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3bf688f3-588a-42cd-8968-934e41cd9723"",
                    ""path"": ""<XRHMD>/deviceRotation"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HeadRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""49e51485-5be3-4b32-b5be-4c9dff4af8fb"",
                    ""path"": ""<XRController>{LeftHand}/devicePosition"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftHandPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""810d6bbe-cc98-4dc3-b76f-da9cb9718a48"",
                    ""path"": ""<XRController>{LeftHand}/deviceRotation"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftHandRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de7c9245-7b6f-4c98-96bf-3e77cde813c4"",
                    ""path"": ""<XRController>{RightHand}/devicePosition"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightHandPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0e8ca6a2-35df-4b56-8f43-91bef433d5e0"",
                    ""path"": ""<XRController>{RightHand}/deviceRotation"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightHandRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Blah"",
            ""id"": ""e406d241-99cb-4940-b933-9d6c0e7e532b"",
            ""actions"": [
                {
                    ""name"": ""Blah1"",
                    ""type"": ""Button"",
                    ""id"": ""4fdf64be-1a56-4dab-846a-c02adf30646c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Blah2"",
                    ""type"": ""Button"",
                    ""id"": ""8b73939e-9b1e-40da-976c-be69dfbba788"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6b6a9b44-285a-4cd2-824c-cd400ce88700"",
                    ""path"": ""<Keyboard>/leftBracket"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Blah1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f617c009-9cb7-4296-819b-0fd69a05befc"",
                    ""path"": ""<Keyboard>/rightBracket"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Blah2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""XR Controller"",
            ""bindingGroup"": ""XR Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<XRController>{LeftHand}"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<XRController>{RightHand}"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Mouse And Keyboard"",
            ""bindingGroup"": ""Mouse And Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // XRPlayerController
        m_XRPlayerController = asset.FindActionMap("XRPlayerController", throwIfNotFound: true);
        m_XRPlayerController_Move = m_XRPlayerController.FindAction("Move", throwIfNotFound: true);
        m_XRPlayerController_RotateCamera = m_XRPlayerController.FindAction("Rotate Camera", throwIfNotFound: true);
        m_XRPlayerController_Teleport = m_XRPlayerController.FindAction("Teleport", throwIfNotFound: true);
        m_XRPlayerController_Interact = m_XRPlayerController.FindAction("Interact", throwIfNotFound: true);
        // XRAvatar
        m_XRAvatar = asset.FindActionMap("XRAvatar", throwIfNotFound: true);
        m_XRAvatar_HeadPosition = m_XRAvatar.FindAction("HeadPosition", throwIfNotFound: true);
        m_XRAvatar_HeadRotation = m_XRAvatar.FindAction("HeadRotation", throwIfNotFound: true);
        m_XRAvatar_LeftHandPosition = m_XRAvatar.FindAction("LeftHandPosition", throwIfNotFound: true);
        m_XRAvatar_LeftHandRotation = m_XRAvatar.FindAction("LeftHandRotation", throwIfNotFound: true);
        m_XRAvatar_RightHandPosition = m_XRAvatar.FindAction("RightHandPosition", throwIfNotFound: true);
        m_XRAvatar_RightHandRotation = m_XRAvatar.FindAction("RightHandRotation", throwIfNotFound: true);
        // Blah
        m_Blah = asset.FindActionMap("Blah", throwIfNotFound: true);
        m_Blah_Blah1 = m_Blah.FindAction("Blah1", throwIfNotFound: true);
        m_Blah_Blah2 = m_Blah.FindAction("Blah2", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // XRPlayerController
    private readonly InputActionMap m_XRPlayerController;
    private IXRPlayerControllerActions m_XRPlayerControllerActionsCallbackInterface;
    private readonly InputAction m_XRPlayerController_Move;
    private readonly InputAction m_XRPlayerController_RotateCamera;
    private readonly InputAction m_XRPlayerController_Teleport;
    private readonly InputAction m_XRPlayerController_Interact;
    public struct XRPlayerControllerActions
    {
        private @XRInputActions m_Wrapper;
        public XRPlayerControllerActions(@XRInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_XRPlayerController_Move;
        public InputAction @RotateCamera => m_Wrapper.m_XRPlayerController_RotateCamera;
        public InputAction @Teleport => m_Wrapper.m_XRPlayerController_Teleport;
        public InputAction @Interact => m_Wrapper.m_XRPlayerController_Interact;
        public InputActionMap Get() { return m_Wrapper.m_XRPlayerController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(XRPlayerControllerActions set) { return set.Get(); }
        public void SetCallbacks(IXRPlayerControllerActions instance)
        {
            if (m_Wrapper.m_XRPlayerControllerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_XRPlayerControllerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_XRPlayerControllerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_XRPlayerControllerActionsCallbackInterface.OnMove;
                @RotateCamera.started -= m_Wrapper.m_XRPlayerControllerActionsCallbackInterface.OnRotateCamera;
                @RotateCamera.performed -= m_Wrapper.m_XRPlayerControllerActionsCallbackInterface.OnRotateCamera;
                @RotateCamera.canceled -= m_Wrapper.m_XRPlayerControllerActionsCallbackInterface.OnRotateCamera;
                @Teleport.started -= m_Wrapper.m_XRPlayerControllerActionsCallbackInterface.OnTeleport;
                @Teleport.performed -= m_Wrapper.m_XRPlayerControllerActionsCallbackInterface.OnTeleport;
                @Teleport.canceled -= m_Wrapper.m_XRPlayerControllerActionsCallbackInterface.OnTeleport;
                @Interact.started -= m_Wrapper.m_XRPlayerControllerActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_XRPlayerControllerActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_XRPlayerControllerActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_XRPlayerControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @RotateCamera.started += instance.OnRotateCamera;
                @RotateCamera.performed += instance.OnRotateCamera;
                @RotateCamera.canceled += instance.OnRotateCamera;
                @Teleport.started += instance.OnTeleport;
                @Teleport.performed += instance.OnTeleport;
                @Teleport.canceled += instance.OnTeleport;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public XRPlayerControllerActions @XRPlayerController => new XRPlayerControllerActions(this);

    // XRAvatar
    private readonly InputActionMap m_XRAvatar;
    private IXRAvatarActions m_XRAvatarActionsCallbackInterface;
    private readonly InputAction m_XRAvatar_HeadPosition;
    private readonly InputAction m_XRAvatar_HeadRotation;
    private readonly InputAction m_XRAvatar_LeftHandPosition;
    private readonly InputAction m_XRAvatar_LeftHandRotation;
    private readonly InputAction m_XRAvatar_RightHandPosition;
    private readonly InputAction m_XRAvatar_RightHandRotation;
    public struct XRAvatarActions
    {
        private @XRInputActions m_Wrapper;
        public XRAvatarActions(@XRInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @HeadPosition => m_Wrapper.m_XRAvatar_HeadPosition;
        public InputAction @HeadRotation => m_Wrapper.m_XRAvatar_HeadRotation;
        public InputAction @LeftHandPosition => m_Wrapper.m_XRAvatar_LeftHandPosition;
        public InputAction @LeftHandRotation => m_Wrapper.m_XRAvatar_LeftHandRotation;
        public InputAction @RightHandPosition => m_Wrapper.m_XRAvatar_RightHandPosition;
        public InputAction @RightHandRotation => m_Wrapper.m_XRAvatar_RightHandRotation;
        public InputActionMap Get() { return m_Wrapper.m_XRAvatar; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(XRAvatarActions set) { return set.Get(); }
        public void SetCallbacks(IXRAvatarActions instance)
        {
            if (m_Wrapper.m_XRAvatarActionsCallbackInterface != null)
            {
                @HeadPosition.started -= m_Wrapper.m_XRAvatarActionsCallbackInterface.OnHeadPosition;
                @HeadPosition.performed -= m_Wrapper.m_XRAvatarActionsCallbackInterface.OnHeadPosition;
                @HeadPosition.canceled -= m_Wrapper.m_XRAvatarActionsCallbackInterface.OnHeadPosition;
                @HeadRotation.started -= m_Wrapper.m_XRAvatarActionsCallbackInterface.OnHeadRotation;
                @HeadRotation.performed -= m_Wrapper.m_XRAvatarActionsCallbackInterface.OnHeadRotation;
                @HeadRotation.canceled -= m_Wrapper.m_XRAvatarActionsCallbackInterface.OnHeadRotation;
                @LeftHandPosition.started -= m_Wrapper.m_XRAvatarActionsCallbackInterface.OnLeftHandPosition;
                @LeftHandPosition.performed -= m_Wrapper.m_XRAvatarActionsCallbackInterface.OnLeftHandPosition;
                @LeftHandPosition.canceled -= m_Wrapper.m_XRAvatarActionsCallbackInterface.OnLeftHandPosition;
                @LeftHandRotation.started -= m_Wrapper.m_XRAvatarActionsCallbackInterface.OnLeftHandRotation;
                @LeftHandRotation.performed -= m_Wrapper.m_XRAvatarActionsCallbackInterface.OnLeftHandRotation;
                @LeftHandRotation.canceled -= m_Wrapper.m_XRAvatarActionsCallbackInterface.OnLeftHandRotation;
                @RightHandPosition.started -= m_Wrapper.m_XRAvatarActionsCallbackInterface.OnRightHandPosition;
                @RightHandPosition.performed -= m_Wrapper.m_XRAvatarActionsCallbackInterface.OnRightHandPosition;
                @RightHandPosition.canceled -= m_Wrapper.m_XRAvatarActionsCallbackInterface.OnRightHandPosition;
                @RightHandRotation.started -= m_Wrapper.m_XRAvatarActionsCallbackInterface.OnRightHandRotation;
                @RightHandRotation.performed -= m_Wrapper.m_XRAvatarActionsCallbackInterface.OnRightHandRotation;
                @RightHandRotation.canceled -= m_Wrapper.m_XRAvatarActionsCallbackInterface.OnRightHandRotation;
            }
            m_Wrapper.m_XRAvatarActionsCallbackInterface = instance;
            if (instance != null)
            {
                @HeadPosition.started += instance.OnHeadPosition;
                @HeadPosition.performed += instance.OnHeadPosition;
                @HeadPosition.canceled += instance.OnHeadPosition;
                @HeadRotation.started += instance.OnHeadRotation;
                @HeadRotation.performed += instance.OnHeadRotation;
                @HeadRotation.canceled += instance.OnHeadRotation;
                @LeftHandPosition.started += instance.OnLeftHandPosition;
                @LeftHandPosition.performed += instance.OnLeftHandPosition;
                @LeftHandPosition.canceled += instance.OnLeftHandPosition;
                @LeftHandRotation.started += instance.OnLeftHandRotation;
                @LeftHandRotation.performed += instance.OnLeftHandRotation;
                @LeftHandRotation.canceled += instance.OnLeftHandRotation;
                @RightHandPosition.started += instance.OnRightHandPosition;
                @RightHandPosition.performed += instance.OnRightHandPosition;
                @RightHandPosition.canceled += instance.OnRightHandPosition;
                @RightHandRotation.started += instance.OnRightHandRotation;
                @RightHandRotation.performed += instance.OnRightHandRotation;
                @RightHandRotation.canceled += instance.OnRightHandRotation;
            }
        }
    }
    public XRAvatarActions @XRAvatar => new XRAvatarActions(this);

    // Blah
    private readonly InputActionMap m_Blah;
    private IBlahActions m_BlahActionsCallbackInterface;
    private readonly InputAction m_Blah_Blah1;
    private readonly InputAction m_Blah_Blah2;
    public struct BlahActions
    {
        private @XRInputActions m_Wrapper;
        public BlahActions(@XRInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Blah1 => m_Wrapper.m_Blah_Blah1;
        public InputAction @Blah2 => m_Wrapper.m_Blah_Blah2;
        public InputActionMap Get() { return m_Wrapper.m_Blah; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BlahActions set) { return set.Get(); }
        public void SetCallbacks(IBlahActions instance)
        {
            if (m_Wrapper.m_BlahActionsCallbackInterface != null)
            {
                @Blah1.started -= m_Wrapper.m_BlahActionsCallbackInterface.OnBlah1;
                @Blah1.performed -= m_Wrapper.m_BlahActionsCallbackInterface.OnBlah1;
                @Blah1.canceled -= m_Wrapper.m_BlahActionsCallbackInterface.OnBlah1;
                @Blah2.started -= m_Wrapper.m_BlahActionsCallbackInterface.OnBlah2;
                @Blah2.performed -= m_Wrapper.m_BlahActionsCallbackInterface.OnBlah2;
                @Blah2.canceled -= m_Wrapper.m_BlahActionsCallbackInterface.OnBlah2;
            }
            m_Wrapper.m_BlahActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Blah1.started += instance.OnBlah1;
                @Blah1.performed += instance.OnBlah1;
                @Blah1.canceled += instance.OnBlah1;
                @Blah2.started += instance.OnBlah2;
                @Blah2.performed += instance.OnBlah2;
                @Blah2.canceled += instance.OnBlah2;
            }
        }
    }
    public BlahActions @Blah => new BlahActions(this);
    private int m_XRControllerSchemeIndex = -1;
    public InputControlScheme XRControllerScheme
    {
        get
        {
            if (m_XRControllerSchemeIndex == -1) m_XRControllerSchemeIndex = asset.FindControlSchemeIndex("XR Controller");
            return asset.controlSchemes[m_XRControllerSchemeIndex];
        }
    }
    private int m_MouseAndKeyboardSchemeIndex = -1;
    public InputControlScheme MouseAndKeyboardScheme
    {
        get
        {
            if (m_MouseAndKeyboardSchemeIndex == -1) m_MouseAndKeyboardSchemeIndex = asset.FindControlSchemeIndex("Mouse And Keyboard");
            return asset.controlSchemes[m_MouseAndKeyboardSchemeIndex];
        }
    }
    public interface IXRPlayerControllerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRotateCamera(InputAction.CallbackContext context);
        void OnTeleport(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
    public interface IXRAvatarActions
    {
        void OnHeadPosition(InputAction.CallbackContext context);
        void OnHeadRotation(InputAction.CallbackContext context);
        void OnLeftHandPosition(InputAction.CallbackContext context);
        void OnLeftHandRotation(InputAction.CallbackContext context);
        void OnRightHandPosition(InputAction.CallbackContext context);
        void OnRightHandRotation(InputAction.CallbackContext context);
    }
    public interface IBlahActions
    {
        void OnBlah1(InputAction.CallbackContext context);
        void OnBlah2(InputAction.CallbackContext context);
    }
}
