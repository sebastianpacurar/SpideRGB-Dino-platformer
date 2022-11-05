//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.3
//     from Assets/Scripts/Player/PlayerControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Player
{
    public partial class @PlayerControls : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Dino"",
            ""id"": ""135962b1-2c49-496a-9afb-90ad98ea2850"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""f24f806f-0e26-4eb0-83c6-c1a9b124b02b"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""454e8e82-280e-444a-9a48-e343366a5849"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Value"",
                    ""id"": ""30d2003e-c665-4864-9da1-0ececcb135df"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Throw"",
                    ""type"": ""Button"",
                    ""id"": ""b1c16e4c-17cc-4f4a-b3b7-fe3a984a18ab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d56a90ba-77db-48c9-b7c6-6edbffa00341"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""09f8b294-f807-44f6-aea8-97d7ef545bf2"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""81c6efc2-824a-4e80-b200-76f0cf18ef92"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""817ec741-4f51-4b2d-abfb-a4171649ca50"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6f88a314-872d-4e03-8c8a-f5f1775a261e"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""539037ae-4a5e-44b7-ae7d-bc50f935e09d"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Dino
            m_Dino = asset.FindActionMap("Dino", throwIfNotFound: true);
            m_Dino_Move = m_Dino.FindAction("Move", throwIfNotFound: true);
            m_Dino_Jump = m_Dino.FindAction("Jump", throwIfNotFound: true);
            m_Dino_Aim = m_Dino.FindAction("Aim", throwIfNotFound: true);
            m_Dino_Throw = m_Dino.FindAction("Throw", throwIfNotFound: true);
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
        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }
        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // Dino
        private readonly InputActionMap m_Dino;
        private IDinoActions m_DinoActionsCallbackInterface;
        private readonly InputAction m_Dino_Move;
        private readonly InputAction m_Dino_Jump;
        private readonly InputAction m_Dino_Aim;
        private readonly InputAction m_Dino_Throw;
        public struct DinoActions
        {
            private @PlayerControls m_Wrapper;
            public DinoActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Dino_Move;
            public InputAction @Jump => m_Wrapper.m_Dino_Jump;
            public InputAction @Aim => m_Wrapper.m_Dino_Aim;
            public InputAction @Throw => m_Wrapper.m_Dino_Throw;
            public InputActionMap Get() { return m_Wrapper.m_Dino; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(DinoActions set) { return set.Get(); }
            public void SetCallbacks(IDinoActions instance)
            {
                if (m_Wrapper.m_DinoActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_DinoActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_DinoActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_DinoActionsCallbackInterface.OnMove;
                    @Jump.started -= m_Wrapper.m_DinoActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_DinoActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_DinoActionsCallbackInterface.OnJump;
                    @Aim.started -= m_Wrapper.m_DinoActionsCallbackInterface.OnAim;
                    @Aim.performed -= m_Wrapper.m_DinoActionsCallbackInterface.OnAim;
                    @Aim.canceled -= m_Wrapper.m_DinoActionsCallbackInterface.OnAim;
                    @Throw.started -= m_Wrapper.m_DinoActionsCallbackInterface.OnThrow;
                    @Throw.performed -= m_Wrapper.m_DinoActionsCallbackInterface.OnThrow;
                    @Throw.canceled -= m_Wrapper.m_DinoActionsCallbackInterface.OnThrow;
                }
                m_Wrapper.m_DinoActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                    @Aim.started += instance.OnAim;
                    @Aim.performed += instance.OnAim;
                    @Aim.canceled += instance.OnAim;
                    @Throw.started += instance.OnThrow;
                    @Throw.performed += instance.OnThrow;
                    @Throw.canceled += instance.OnThrow;
                }
            }
        }
        public DinoActions @Dino => new DinoActions(this);
        private int m_KeyboardMouseSchemeIndex = -1;
        public InputControlScheme KeyboardMouseScheme
        {
            get
            {
                if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
                return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
            }
        }
        public interface IDinoActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnAim(InputAction.CallbackContext context);
            void OnThrow(InputAction.CallbackContext context);
        }
    }
}
