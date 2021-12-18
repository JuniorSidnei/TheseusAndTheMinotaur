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
                },
                {
                    ""name"": ""next_level"",
                    ""type"": ""Button"",
                    ""id"": ""3cb52bca-e9ed-4112-9f4d-d801765acf8f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""wait_action"",
                    ""type"": ""Button"",
                    ""id"": ""9dc1c894-a754-4481-9e85-b4eac5d49cc8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""undo_action"",
                    ""type"": ""Button"",
                    ""id"": ""d6a9a75b-092b-48b8-9e00-7abf4e414a75"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""previous_level"",
                    ""type"": ""Button"",
                    ""id"": ""4b850e7c-0b29-4265-aab4-3edd4c031329"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""7a110c4f-d95f-4ffe-a44d-befada6406c7"",
                    ""path"": ""<Keyboard>/n"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""next_level"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c75f8b75-ced1-4d0f-97bd-09224eb11b11"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""wait_action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bc1f7da0-1073-4e41-b6d2-a618c84fc6d2"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""undo_action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4ee95727-1034-4f57-a091-376abb0e97a1"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""previous_level"",
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
        m_Player_next_level = m_Player.FindAction("next_level", throwIfNotFound: true);
        m_Player_wait_action = m_Player.FindAction("wait_action", throwIfNotFound: true);
        m_Player_undo_action = m_Player.FindAction("undo_action", throwIfNotFound: true);
        m_Player_previous_level = m_Player.FindAction("previous_level", throwIfNotFound: true);
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
    private readonly InputAction m_Player_next_level;
    private readonly InputAction m_Player_wait_action;
    private readonly InputAction m_Player_undo_action;
    private readonly InputAction m_Player_previous_level;
    public struct PlayerActions
    {
        private @InputActions m_Wrapper;
        public PlayerActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @player_movement => m_Wrapper.m_Player_player_movement;
        public InputAction @restart => m_Wrapper.m_Player_restart;
        public InputAction @next_level => m_Wrapper.m_Player_next_level;
        public InputAction @wait_action => m_Wrapper.m_Player_wait_action;
        public InputAction @undo_action => m_Wrapper.m_Player_undo_action;
        public InputAction @previous_level => m_Wrapper.m_Player_previous_level;
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
                @next_level.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNext_level;
                @next_level.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNext_level;
                @next_level.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNext_level;
                @wait_action.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWait_action;
                @wait_action.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWait_action;
                @wait_action.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWait_action;
                @undo_action.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUndo_action;
                @undo_action.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUndo_action;
                @undo_action.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUndo_action;
                @previous_level.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPrevious_level;
                @previous_level.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPrevious_level;
                @previous_level.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPrevious_level;
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
                @next_level.started += instance.OnNext_level;
                @next_level.performed += instance.OnNext_level;
                @next_level.canceled += instance.OnNext_level;
                @wait_action.started += instance.OnWait_action;
                @wait_action.performed += instance.OnWait_action;
                @wait_action.canceled += instance.OnWait_action;
                @undo_action.started += instance.OnUndo_action;
                @undo_action.performed += instance.OnUndo_action;
                @undo_action.canceled += instance.OnUndo_action;
                @previous_level.started += instance.OnPrevious_level;
                @previous_level.performed += instance.OnPrevious_level;
                @previous_level.canceled += instance.OnPrevious_level;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnPlayer_movement(InputAction.CallbackContext context);
        void OnRestart(InputAction.CallbackContext context);
        void OnNext_level(InputAction.CallbackContext context);
        void OnWait_action(InputAction.CallbackContext context);
        void OnUndo_action(InputAction.CallbackContext context);
        void OnPrevious_level(InputAction.CallbackContext context);
    }
}
