using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TheseusAndMinotaur.Managers {

    public class GameManager : MonoBehaviour {

        public static GameManager Instance;

        public delegate void OnMovementInput(Vector2Int inputMovement);
        public static event OnMovementInput OnMoveToDirection;
        
        private InputActions m_inputActions;
        
        private void Awake() {
            //create instance, new input action maps
            Instance = this;
            m_inputActions = new InputActions();
            m_inputActions.Enable();

            //subscribe action movement event
            m_inputActions.Player.player_movement.performed += InputMovement;
        }
        

        private void InputMovement(InputAction.CallbackContext ctx) {
            var direction = ctx.ReadValue<Vector2>();
            var directionInt = new Vector2Int((int) direction.x, (int) direction.y);
            OnMoveToDirection?.Invoke(directionInt);
        }
    }
}