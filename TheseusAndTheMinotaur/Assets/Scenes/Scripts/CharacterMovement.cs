using System.Collections;
using System.Collections.Generic;
using System.Net;
using DG.Tweening;
using TheseusAndMinotaur.Character;
using TheseusAndMinotaur.Managers;
using UnityEngine;
using CharacterController = TheseusAndMinotaur.Character.CharacterController;

namespace TheseusAndMinotaur.Player {
    public class CharacterMovement : MonoBehaviour {

        public Vector3Int CharacterInitialPosition;
        public LevelManager LevelManager;
        public BoxCollisionManager BoxCollisionManager;
        
        public delegate void OnFinisTurn(GameManager.CharacterTurn nextTurn);
        public static event OnFinisTurn OnFinishTurn;
        
        public delegate void OnPlayerWin();
        public static event OnPlayerWin OnPlayerWins;
        
        
        private Vector2Int m_currentPosition;
        private Vector2Int m_lastPosition;
        private bool m_isMoving;
        private bool m_isUndoMovement;

        private CharacterController.CharacterType m_type;
        
        public Vector2Int CurrentPosition => m_currentPosition;

        public CharacterController.CharacterType Type {
            get => m_type;
            set => m_type = value;
        }
        
        private void Awake() {
            //Character initial and current position in grid
            m_currentPosition = new Vector2Int(CharacterInitialPosition.x, CharacterInitialPosition.y);
            
            //Player position in world converted from grid
            var position = LevelManager.GetGrid().CellToWorld(CharacterInitialPosition);
            transform.position = position;

            GameManager.OnWaitPlayerAction += OnWaitPlayerAction;
        }
        
        
        public void OnMoveToDirection(Vector2Int direction) {
            //if moving not finished just return
            if (m_isMoving) return;
            
            //check if we can move with direction
            if(!BoxCollisionManager.CanIMoveInDirection(direction)) {
                if (m_type == CharacterController.CharacterType.Theseus) return;
                
                var minotaur = GetComponent<MinotaurController>();
                minotaur.NumberOfMovements = 1;
                OnFinishTurn?.Invoke(GameManager.CharacterTurn.TheseusTurn);  
                return;
            }
            
            //calculate new position to move and store last position for undo
            var nextPositionInGrid = m_currentPosition + direction;
            if (m_type == CharacterController.CharacterType.Minotaur) {
                var minotaur = GetComponent<MinotaurController>();
                
                if (minotaur.NumberOfMovements == 1) {
                    minotaur.LastMinotaurPosition = m_currentPosition;    
                }    
            }
            else {
                m_lastPosition = m_currentPosition;    
            }
            
            
            //convert to world position
            var nextPosition = LevelManager.GetGrid().CellToLocal((Vector3Int) nextPositionInGrid);

            //move to destined position on each axis
            if (direction == Vector2Int.right || direction == Vector2Int.left) {
                //set the player is moving
                m_isMoving = true;
                //move with doTween to smooth movement
                transform.DOMoveX(nextPosition.x, 0.2f).OnComplete(() => {
                    //when finish moving, set the new position and moving complete
                    FinishMovement(nextPositionInGrid);
                });
            } else if (direction == Vector2Int.up || direction == Vector2Int.down) {
                m_isMoving = true;
                transform.DOMoveY(nextPosition.y, 0.2f).OnComplete(() => {
                    FinishMovement(nextPositionInGrid);
                });
            }
        }

        public void OnUndoMove() {
            if (m_isMoving) return;
            
            m_isMoving = true;
            var lastPos = Vector3.zero;
            
            if (m_type == CharacterController.CharacterType.Minotaur) {
                m_currentPosition = GetComponent<MinotaurController>().LastMinotaurPosition;
                lastPos = LevelManager.GetGrid().CellToLocal((Vector3Int) m_currentPosition);    
            }
            else {
                m_currentPosition = m_lastPosition; 
                lastPos = LevelManager.GetGrid().CellToLocal((Vector3Int) m_lastPosition);   
            }
            
            transform.DOMove(lastPos, 0.2f).OnComplete(() => {
                m_isMoving = false;
            });
        }
        
        private void OnWaitPlayerAction() {
            OnFinishTurn?.Invoke(GameManager.CharacterTurn.MinotaurTurn);
        }
        
        private void FinishMovement(Vector2Int nextPositionInGrid) {
            m_currentPosition = nextPositionInGrid;
            m_isMoving = false;

            //when finish turn, validate the next turn
            if (m_type == CharacterController.CharacterType.Theseus) {
                if (CurrentPosition == LevelManager.EndGamePosition) {
                    OnPlayerWins?.Invoke();
                    return;
                }
                
                OnFinishTurn?.Invoke(GameManager.CharacterTurn.MinotaurTurn);
            }
            else {
                var minotaur = GetComponent<MinotaurController>();
                
                if (minotaur.CheckIfReachedPlayerPosition()) {
                    return;
                }
                
                //validate the number of movements for minotaur
                if (minotaur.NumberOfMovements == 0) {
                    minotaur.NumberOfMovements = 1;
                    OnFinishTurn?.Invoke(GameManager.CharacterTurn.TheseusTurn);    
                }
                else {

                    minotaur.NumberOfMovements -= 1;
                    OnFinishTurn?.Invoke(GameManager.CharacterTurn.MinotaurTurn);
                }
            }
        }
    }
}