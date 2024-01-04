//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/BoxHead/Settings/PlayerInputActions.inputactions
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

public partial class @PlayerInputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""74da7525-c60b-4808-b4f0-cfecdd21c1fe"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""baec3f46-f219-4780-8942-ac1168a6d130"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": ""NormalizeVector3"",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""b7ae9b8b-3e0b-4772-966c-c162e1e26017"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""SlowTap(duration=0.06,pressPoint=0.5)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""a9897768-ccc5-4eef-bb05-0aa64e2145bc"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""73a5674e-f4fc-439a-8d73-1ff728815279"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""ac1d721f-b8dd-4392-a838-9cd70c5f7e41"",
                    ""path"": ""3DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7d9ae34b-e5c1-44d6-bb6b-204183da7496"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b2a9f592-56e3-4204-8073-5df694b1cd48"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3b80acb0-12e5-47a4-a93b-eec1f6184014"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1862253a-8b2d-41e3-aecc-075206ca3b0b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""forward"",
                    ""id"": ""a7821572-ec63-4b93-8b66-85fe9c77bcba"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""backward"",
                    ""id"": ""fed05f1a-7d3d-4340-a91a-55ed63140ba0"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""de4098a7-c57c-46b8-a621-71fcef8b1bbb"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ffca0304-89c1-4409-a70b-598db21c1dfd"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""18e5f1ec-4981-40a6-837d-e78cc043a996"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Weapons"",
            ""id"": ""3a29be3f-3500-4e85-8803-556f3f06c4e0"",
            ""actions"": [
                {
                    ""name"": ""Slot 1"",
                    ""type"": ""Button"",
                    ""id"": ""75249ad8-35f1-49f6-b3ec-8d006998910b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Slot 2"",
                    ""type"": ""Button"",
                    ""id"": ""bcc5c07e-fba7-4e50-8da5-784814f218b3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Slot 3"",
                    ""type"": ""Button"",
                    ""id"": ""14e3a1d8-aaf6-4134-8abe-a7648c7d86c1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Slot 4"",
                    ""type"": ""Button"",
                    ""id"": ""9b22032a-b393-4712-9d79-1a6b86ba89d2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Slot 5"",
                    ""type"": ""Button"",
                    ""id"": ""ba73baac-723e-4eb1-b3ce-d00cefa43271"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Slot 6"",
                    ""type"": ""Button"",
                    ""id"": ""8b55ccc7-5877-4ae3-9dbf-fdd1ac850dda"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Slot 7"",
                    ""type"": ""Button"",
                    ""id"": ""18482424-426d-4b9e-ae3c-625fb50e8e6b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Slot 8"",
                    ""type"": ""Button"",
                    ""id"": ""a50e93b3-31ad-4923-9fbc-e1cc3fcbe474"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Slot 9"",
                    ""type"": ""Button"",
                    ""id"": ""9d6ffc8b-585d-4c5a-a6b0-5de00a1e47f7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""29fc3a56-b0aa-44be-a193-be3da2cc0e75"",
                    ""path"": ""<Keyboard>/9"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Slot 9"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b098a65b-79d6-4493-b8ff-58ec243a8c4e"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Slot 1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d26bb77a-618a-425f-af08-bd74ff1e9124"",
                    ""path"": ""<Keyboard>/8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Slot 8"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""39fe630a-11b3-4f9f-a404-4e737f6dc7a1"",
                    ""path"": ""<Keyboard>/7"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Slot 7"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""10415e44-a550-45bc-898c-ad979e46af95"",
                    ""path"": ""<Keyboard>/6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Slot 6"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1dc41292-74fd-4993-bdc4-f9184cc7646a"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Slot 5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""69b816c4-dd8f-400a-acd1-7e0d3f4011d5"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Slot 4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""52c6930f-d8d7-47e0-a262-5d82295f3ec0"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Slot 3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d7ae594e-a7aa-4054-87d1-446af596b046"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Slot 2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PC"",
            ""bindingGroup"": ""PC"",
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
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Look = m_Player.FindAction("Look", throwIfNotFound: true);
        m_Player_Shoot = m_Player.FindAction("Shoot", throwIfNotFound: true);
        // Weapons
        m_Weapons = asset.FindActionMap("Weapons", throwIfNotFound: true);
        m_Weapons_Slot1 = m_Weapons.FindAction("Slot 1", throwIfNotFound: true);
        m_Weapons_Slot2 = m_Weapons.FindAction("Slot 2", throwIfNotFound: true);
        m_Weapons_Slot3 = m_Weapons.FindAction("Slot 3", throwIfNotFound: true);
        m_Weapons_Slot4 = m_Weapons.FindAction("Slot 4", throwIfNotFound: true);
        m_Weapons_Slot5 = m_Weapons.FindAction("Slot 5", throwIfNotFound: true);
        m_Weapons_Slot6 = m_Weapons.FindAction("Slot 6", throwIfNotFound: true);
        m_Weapons_Slot7 = m_Weapons.FindAction("Slot 7", throwIfNotFound: true);
        m_Weapons_Slot8 = m_Weapons.FindAction("Slot 8", throwIfNotFound: true);
        m_Weapons_Slot9 = m_Weapons.FindAction("Slot 9", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Look;
    private readonly InputAction m_Player_Shoot;
    public struct PlayerActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Look => m_Wrapper.m_Player_Look;
        public InputAction @Shoot => m_Wrapper.m_Player_Shoot;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Look.started += instance.OnLook;
            @Look.performed += instance.OnLook;
            @Look.canceled += instance.OnLook;
            @Shoot.started += instance.OnShoot;
            @Shoot.performed += instance.OnShoot;
            @Shoot.canceled += instance.OnShoot;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Look.started -= instance.OnLook;
            @Look.performed -= instance.OnLook;
            @Look.canceled -= instance.OnLook;
            @Shoot.started -= instance.OnShoot;
            @Shoot.performed -= instance.OnShoot;
            @Shoot.canceled -= instance.OnShoot;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Weapons
    private readonly InputActionMap m_Weapons;
    private List<IWeaponsActions> m_WeaponsActionsCallbackInterfaces = new List<IWeaponsActions>();
    private readonly InputAction m_Weapons_Slot1;
    private readonly InputAction m_Weapons_Slot2;
    private readonly InputAction m_Weapons_Slot3;
    private readonly InputAction m_Weapons_Slot4;
    private readonly InputAction m_Weapons_Slot5;
    private readonly InputAction m_Weapons_Slot6;
    private readonly InputAction m_Weapons_Slot7;
    private readonly InputAction m_Weapons_Slot8;
    private readonly InputAction m_Weapons_Slot9;
    public struct WeaponsActions
    {
        private @PlayerInputActions m_Wrapper;
        public WeaponsActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Slot1 => m_Wrapper.m_Weapons_Slot1;
        public InputAction @Slot2 => m_Wrapper.m_Weapons_Slot2;
        public InputAction @Slot3 => m_Wrapper.m_Weapons_Slot3;
        public InputAction @Slot4 => m_Wrapper.m_Weapons_Slot4;
        public InputAction @Slot5 => m_Wrapper.m_Weapons_Slot5;
        public InputAction @Slot6 => m_Wrapper.m_Weapons_Slot6;
        public InputAction @Slot7 => m_Wrapper.m_Weapons_Slot7;
        public InputAction @Slot8 => m_Wrapper.m_Weapons_Slot8;
        public InputAction @Slot9 => m_Wrapper.m_Weapons_Slot9;
        public InputActionMap Get() { return m_Wrapper.m_Weapons; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(WeaponsActions set) { return set.Get(); }
        public void AddCallbacks(IWeaponsActions instance)
        {
            if (instance == null || m_Wrapper.m_WeaponsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_WeaponsActionsCallbackInterfaces.Add(instance);
            @Slot1.started += instance.OnSlot1;
            @Slot1.performed += instance.OnSlot1;
            @Slot1.canceled += instance.OnSlot1;
            @Slot2.started += instance.OnSlot2;
            @Slot2.performed += instance.OnSlot2;
            @Slot2.canceled += instance.OnSlot2;
            @Slot3.started += instance.OnSlot3;
            @Slot3.performed += instance.OnSlot3;
            @Slot3.canceled += instance.OnSlot3;
            @Slot4.started += instance.OnSlot4;
            @Slot4.performed += instance.OnSlot4;
            @Slot4.canceled += instance.OnSlot4;
            @Slot5.started += instance.OnSlot5;
            @Slot5.performed += instance.OnSlot5;
            @Slot5.canceled += instance.OnSlot5;
            @Slot6.started += instance.OnSlot6;
            @Slot6.performed += instance.OnSlot6;
            @Slot6.canceled += instance.OnSlot6;
            @Slot7.started += instance.OnSlot7;
            @Slot7.performed += instance.OnSlot7;
            @Slot7.canceled += instance.OnSlot7;
            @Slot8.started += instance.OnSlot8;
            @Slot8.performed += instance.OnSlot8;
            @Slot8.canceled += instance.OnSlot8;
            @Slot9.started += instance.OnSlot9;
            @Slot9.performed += instance.OnSlot9;
            @Slot9.canceled += instance.OnSlot9;
        }

        private void UnregisterCallbacks(IWeaponsActions instance)
        {
            @Slot1.started -= instance.OnSlot1;
            @Slot1.performed -= instance.OnSlot1;
            @Slot1.canceled -= instance.OnSlot1;
            @Slot2.started -= instance.OnSlot2;
            @Slot2.performed -= instance.OnSlot2;
            @Slot2.canceled -= instance.OnSlot2;
            @Slot3.started -= instance.OnSlot3;
            @Slot3.performed -= instance.OnSlot3;
            @Slot3.canceled -= instance.OnSlot3;
            @Slot4.started -= instance.OnSlot4;
            @Slot4.performed -= instance.OnSlot4;
            @Slot4.canceled -= instance.OnSlot4;
            @Slot5.started -= instance.OnSlot5;
            @Slot5.performed -= instance.OnSlot5;
            @Slot5.canceled -= instance.OnSlot5;
            @Slot6.started -= instance.OnSlot6;
            @Slot6.performed -= instance.OnSlot6;
            @Slot6.canceled -= instance.OnSlot6;
            @Slot7.started -= instance.OnSlot7;
            @Slot7.performed -= instance.OnSlot7;
            @Slot7.canceled -= instance.OnSlot7;
            @Slot8.started -= instance.OnSlot8;
            @Slot8.performed -= instance.OnSlot8;
            @Slot8.canceled -= instance.OnSlot8;
            @Slot9.started -= instance.OnSlot9;
            @Slot9.performed -= instance.OnSlot9;
            @Slot9.canceled -= instance.OnSlot9;
        }

        public void RemoveCallbacks(IWeaponsActions instance)
        {
            if (m_Wrapper.m_WeaponsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IWeaponsActions instance)
        {
            foreach (var item in m_Wrapper.m_WeaponsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_WeaponsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public WeaponsActions @Weapons => new WeaponsActions(this);
    private int m_PCSchemeIndex = -1;
    public InputControlScheme PCScheme
    {
        get
        {
            if (m_PCSchemeIndex == -1) m_PCSchemeIndex = asset.FindControlSchemeIndex("PC");
            return asset.controlSchemes[m_PCSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
    }
    public interface IWeaponsActions
    {
        void OnSlot1(InputAction.CallbackContext context);
        void OnSlot2(InputAction.CallbackContext context);
        void OnSlot3(InputAction.CallbackContext context);
        void OnSlot4(InputAction.CallbackContext context);
        void OnSlot5(InputAction.CallbackContext context);
        void OnSlot6(InputAction.CallbackContext context);
        void OnSlot7(InputAction.CallbackContext context);
        void OnSlot8(InputAction.CallbackContext context);
        void OnSlot9(InputAction.CallbackContext context);
    }
}
