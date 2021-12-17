// GENERATED AUTOMATICALLY FROM 'Assets/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""dd62c316-098c-439a-a7a8-bfc817ff90de"",
            ""actions"": [
                {
                    ""name"": ""player_movement"",
                    ""type"": ""Value"",
                    ""id"": ""4480aa5e-b657-4ea9-ae33-06413600c189"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""restart"",
                    ""type"": ""Button"",
                    ""id"": ""57275b22-5f67-48dd-b049-861b605d2084"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""8b14837c-46a4-4770-b93b-842262638fe8"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""player_movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e8578478-97e1-4f20-b9bf-5ab764bb65bf"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""player_movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""10ce0719-e71a-4040-9451-ddc244c42cab"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""player_movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5c9207be-e6a1-4c08-83a4-da9cce991ec5"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""player_movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d8723b0e-8e57-447b-b25e-b48c1bf7e7a6"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""player_movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""83ddd17e-665e-45b4-94dd-c149138c128b"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_player_movement = m_Player.FindAction("player_movement", throwIfNotFound: true);
        m_Player_restart = m_Player.FindAction("restart", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_player_movement;
    private readonly InputAction m_Player_restart;
    public struct PlayerActions
    {
        private @InputActions m_Wrapper;
        public PlayerActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @player_movement => m_Wrapper.m_Player_player_movement;
        public InputAction @restart => m_Wrapper.m_Player_restart;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @player_movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlayer_movement;
                @player_movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlayer_movement;
                @player_movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlayer_movement;
                @restart.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRestart;
                @restart.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRestart;
                @restart.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRestart;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @player_movement.started += instance.OnPlayer_movement;
                @player_movement.performed += instance.OnPlayer_movement;
                @player_movement.canceled += instance.OnPlayer_movement;
                @restart.started += instance.OnRestart;
                @restart.performed += instance.OnRestart;
                @restart.canceled += instance.OnRestart;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnPlayer_movement(InputAction.CallbackContext context);
        void OnRestart(InputAction.CallbackContext context);
    }
}
