//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
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
                    ""name"": ""Pull"",
                    ""type"": ""Button"",
                    ""id"": ""fdbd8b38-a34f-4ee8-acd5-cb33f689e27a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Push"",
                    ""type"": ""Button"",
                    ""id"": ""f30ec4e5-8000-49f1-97ef-7593ac6b8989"",
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
                    ""id"": ""be222aa5-312b-4565-a377-5b7d64e0e92b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Pull"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fe2a8ad5-dbb6-4809-89d8-8831e7b62d8e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Push"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""9a523d81-e8df-4e78-b409-5884adde71cb"",
            ""actions"": [
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""57a8b31c-1971-411d-9b82-a27702cfd5d9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""30fe1977-3317-4b4e-ba6b-34be447c8dc2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Esc"",
                    ""type"": ""Button"",
                    ""id"": ""b9eb6351-4ad5-42fa-9259-ef7ffdd16cd5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5a1dd56a-7501-429b-a512-6f8efe1c3870"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""91d47c90-e3eb-4570-a982-ef6e686cfa53"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f0cbd19b-276e-4add-a4f3-8838977e6180"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Esc"",
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
            m_Dino_Pull = m_Dino.FindAction("Pull", throwIfNotFound: true);
            m_Dino_Push = m_Dino.FindAction("Push", throwIfNotFound: true);
            // Menu
            m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
            m_Menu_Left = m_Menu.FindAction("Left", throwIfNotFound: true);
            m_Menu_Right = m_Menu.FindAction("Right", throwIfNotFound: true);
            m_Menu_Esc = m_Menu.FindAction("Esc", throwIfNotFound: true);
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
        private readonly InputAction m_Dino_Pull;
        private readonly InputAction m_Dino_Push;
        public struct DinoActions
        {
            private @PlayerControls m_Wrapper;
            public DinoActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Dino_Move;
            public InputAction @Jump => m_Wrapper.m_Dino_Jump;
            public InputAction @Pull => m_Wrapper.m_Dino_Pull;
            public InputAction @Push => m_Wrapper.m_Dino_Push;
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
                    @Pull.started -= m_Wrapper.m_DinoActionsCallbackInterface.OnPull;
                    @Pull.performed -= m_Wrapper.m_DinoActionsCallbackInterface.OnPull;
                    @Pull.canceled -= m_Wrapper.m_DinoActionsCallbackInterface.OnPull;
                    @Push.started -= m_Wrapper.m_DinoActionsCallbackInterface.OnPush;
                    @Push.performed -= m_Wrapper.m_DinoActionsCallbackInterface.OnPush;
                    @Push.canceled -= m_Wrapper.m_DinoActionsCallbackInterface.OnPush;
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
                    @Pull.started += instance.OnPull;
                    @Pull.performed += instance.OnPull;
                    @Pull.canceled += instance.OnPull;
                    @Push.started += instance.OnPush;
                    @Push.performed += instance.OnPush;
                    @Push.canceled += instance.OnPush;
                }
            }
        }
        public DinoActions @Dino => new DinoActions(this);

        // Menu
        private readonly InputActionMap m_Menu;
        private IMenuActions m_MenuActionsCallbackInterface;
        private readonly InputAction m_Menu_Left;
        private readonly InputAction m_Menu_Right;
        private readonly InputAction m_Menu_Esc;
        public struct MenuActions
        {
            private @PlayerControls m_Wrapper;
            public MenuActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Left => m_Wrapper.m_Menu_Left;
            public InputAction @Right => m_Wrapper.m_Menu_Right;
            public InputAction @Esc => m_Wrapper.m_Menu_Esc;
            public InputActionMap Get() { return m_Wrapper.m_Menu; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
            public void SetCallbacks(IMenuActions instance)
            {
                if (m_Wrapper.m_MenuActionsCallbackInterface != null)
                {
                    @Left.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnLeft;
                    @Left.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnLeft;
                    @Left.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnLeft;
                    @Right.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnRight;
                    @Right.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnRight;
                    @Right.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnRight;
                    @Esc.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnEsc;
                    @Esc.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnEsc;
                    @Esc.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnEsc;
                }
                m_Wrapper.m_MenuActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Left.started += instance.OnLeft;
                    @Left.performed += instance.OnLeft;
                    @Left.canceled += instance.OnLeft;
                    @Right.started += instance.OnRight;
                    @Right.performed += instance.OnRight;
                    @Right.canceled += instance.OnRight;
                    @Esc.started += instance.OnEsc;
                    @Esc.performed += instance.OnEsc;
                    @Esc.canceled += instance.OnEsc;
                }
            }
        }
        public MenuActions @Menu => new MenuActions(this);
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
            void OnPull(InputAction.CallbackContext context);
            void OnPush(InputAction.CallbackContext context);
        }
        public interface IMenuActions
        {
            void OnLeft(InputAction.CallbackContext context);
            void OnRight(InputAction.CallbackContext context);
            void OnEsc(InputAction.CallbackContext context);
        }
    }
}
