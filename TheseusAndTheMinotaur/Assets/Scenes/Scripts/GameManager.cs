using System;
using System.Collections;
using System.Collections.Generic;
using TheseusAndMinotaur.Player;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace TheseusAndMinotaur.Managers {

    public class GameManager : MonoBehaviour {
        public enum CharacterTurn {
            TheseusTurn,
            MinotaurTurn
        }

        public TextMeshProUGUI TurnText;
        
        public static GameManager Instance;

        public delegate void OnMovementInput(Vector2Int inputMovement);
        public static event OnMovementInput OnMoveToDirection;
        
        public delegate void OnMinotaurTurn();
        public static event OnMinotaurTurn OnMinotaurMoveTurn;
        
        private InputActions m_inputActions;

        private CharacterTurn m_characterTurn;
        
        private void Awake() {
            //create instance, new input action maps
            Instance = this;
            m_inputActions = new InputActions();
            m_inputActions.Enable();

            //subscribe action movement event
            m_inputActions.Player.player_movement.performed += InputMovement;
            
            //subscribe to restart event
            m_inputActions.Player.restart.performed += RestartGame;
            
            //subscribe finish turn event
            CharacterMovement.OnFinishTurn += OnFinishTurn;

            m_characterTurn = CharacterTurn.TheseusTurn;
            TurnText.SetText("IT'S: " + m_characterTurn);
        }
        
        public CharacterTurn GetCurrentTurn() {
            return m_characterTurn;
        }

        private void RestartGame(InputAction.CallbackContext ctx) {
            SceneManager.LoadScene("Level_01");
        }
        
        private void InputMovement(InputAction.CallbackContext ctx) {
            var direction = ctx.ReadValue<Vector2>();
            var directionInt = new Vector2Int((int) direction.x, (int) direction.y);
            OnMoveToDirection?.Invoke(directionInt);
        }

        private void OnFinishTurn(CharacterTurn nextTurn) {
            m_characterTurn = nextTurn;
            TurnText.SetText("IT'S: " + m_characterTurn);

            if (m_characterTurn == CharacterTurn.TheseusTurn) return;
            
            OnMinotaurMoveTurn?.Invoke();
        }
    }
}