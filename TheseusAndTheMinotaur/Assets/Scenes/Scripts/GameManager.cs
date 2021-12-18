using System;
using System.Collections;
using System.Collections.Generic;
using TheseusAndMinotaur.Character;
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

        public int CurrentLevelID;
        public int NextLevelID;
        public int PreviousLevelID;
        public TextMeshProUGUI TurnText;
        public TextMeshProUGUI NoLevelAdviseText;
        
        [Header("finish game settings")]
        public TextMeshProUGUI FinishText;
        public Color LooseTextColor;
        public Color WinTextColor;
        public GameObject Finish;
        
        public static GameManager Instance;

        public delegate void OnMovementInput(Vector2Int inputMovement);
        public static event OnMovementInput OnMoveToDirection;
        
        public delegate void OnWaitAction();
        public static event OnWaitAction OnWaitPlayerAction;
        
        public delegate void OnUndoAction();
        public static event OnUndoAction OnUndoMovementAction;
        
        public delegate void OnMinotaurTurn();
        public static event OnMinotaurTurn OnMinotaurMoveTurn;

        private InputActions m_inputActions;

        private CharacterTurn m_characterTurn;
        
        private void Awake() {
            //create instance, new input action maps
            Instance = this;
            m_inputActions = new InputActions();
            m_inputActions.Enable();

           
            
            m_characterTurn = CharacterTurn.TheseusTurn;
            TurnText.SetText("IT'S: " + m_characterTurn);
        }

        public void OnEnable() {
            //subscribe action movement event
            m_inputActions.Player.player_movement.performed += InputMovement;
            
            //subscribe to restart event
            m_inputActions.Player.restart.performed += RestartGame;
            
            //subscribe to wait event
            m_inputActions.Player.wait_action.performed += WaitAction;
            
            //subscribe to undo action 
            m_inputActions.Player.undo_action.performed += UndoAction;
            
            //subscribe to next level
            m_inputActions.Player.next_level.performed += NextLevel;
            
            //subscribe to previous level
            m_inputActions.Player.previous_level.performed += PreviousLevel;
            
            //subscribe finish turn event
            CharacterMovement.OnFinishTurn += OnFinishTurn;

            //subscribe to minotaur win event
            MinotaurController.OnMinotaurWins += OnMinotaurWins;
            
            //subscribe to player win event
            CharacterMovement.OnPlayerWins += OnPlayerWins; 
        }

        public void OnDisable() {
            //unsubscribe action movement event
            m_inputActions.Player.player_movement.performed -= InputMovement;
            
            //unsubscribe to restart event
            m_inputActions.Player.restart.performed -= RestartGame;
            
            //unsubscribe to wait event
            m_inputActions.Player.wait_action.performed -= WaitAction;
            
            //unsubscribe to undo action 
            m_inputActions.Player.undo_action.performed -= UndoAction;
            
            //unsubscribe to next level
            m_inputActions.Player.next_level.performed -= NextLevel;
            
            //unsubscribe to previous level
            m_inputActions.Player.previous_level.performed -= PreviousLevel;
            
            //unsubscribe finish turn event
            CharacterMovement.OnFinishTurn -= OnFinishTurn;

            //unsubscribe to minotaur win event
            MinotaurController.OnMinotaurWins -= OnMinotaurWins;
            
            //unsubscribe to player win event
            CharacterMovement.OnPlayerWins -= OnPlayerWins; 
        }

        public CharacterTurn GetCurrentTurn() {
            return m_characterTurn;
        }

        private void RestartGame(InputAction.CallbackContext ctx) {
            SceneManager.LoadScene(string.Format("Level_{0}", CurrentLevelID));
            m_inputActions.Player.player_movement.Enable();
        }

        private void WaitAction(InputAction.CallbackContext ctx) {
            if (m_characterTurn == CharacterTurn.MinotaurTurn) return;
            
            OnWaitPlayerAction?.Invoke();
        }

        private void UndoAction(InputAction.CallbackContext ctx) {
            OnUndoMovementAction?.Invoke();
        }

        private void NextLevel(InputAction.CallbackContext ctx) {
            if (NextLevelID == 0) {
                NoLevelAdviseText.gameObject.SetActive(true);
                Invoke("HideAdviseText", 0.2f);
                return;
            }
            SceneManager.LoadScene(string.Format("Level_{0}", NextLevelID));  
        }
        
        private void PreviousLevel(InputAction.CallbackContext ctx) {
            if (PreviousLevelID == 0) {
                NoLevelAdviseText.gameObject.SetActive(true);
                Invoke("HideAdviseText", 0.2f);
                return;
            }
            SceneManager.LoadScene(string.Format("Level_{0}", PreviousLevelID));  
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

        private void OnMinotaurWins() {
            m_inputActions.Player.player_movement.Disable();
            Finish.gameObject.SetActive(true);
            FinishText.color = LooseTextColor;
            FinishText.text = "LOST - MINOTAUR GOT YOU!";
        }

        private void OnPlayerWins() {
            m_inputActions.Player.player_movement.Disable();
            Finish.gameObject.SetActive(true);
            FinishText.color = WinTextColor;
            FinishText.text = "WIN - YOU HAVE ESCAPED!";
        }

        private void HideAdviseText() {
            NoLevelAdviseText.gameObject.SetActive(false);
        }
    }
}