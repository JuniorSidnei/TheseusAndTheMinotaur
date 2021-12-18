using System;
using System.Collections;
using System.Collections.Generic;
using TheseusAndMinotaur.Managers;
using UnityEngine;

namespace TheseusAndMinotaur.Character {

    public class MinotaurController : CharacterController {
        
        //It he can move one square horizontally and get closer, he will do that.
        //If he can’t move horizontally, then he will try to move vertically.
        //And, most importantly, he will choose a horizontal move before a vertical move.

        public delegate void OnMinotaurWin();
        public static event OnMinotaurWin OnMinotaurWins;
        
        public PlayerController PlayerController;
        
        private int m_numberOfMovements = 1;
        private Vector2Int m_lastTargetPosition;
        private Vector2Int m_lastMinotaurPosition;

        public Vector2Int LastTargetPosition => m_lastTargetPosition;
        public Vector2Int LastMinotaurPosition {
            get =>  m_lastMinotaurPosition;
            set => m_lastMinotaurPosition = value;
        }

        public int NumberOfMovements {
            get => m_numberOfMovements;
            set => m_numberOfMovements = value;
        }
        
        private void Awake() {
            characterMovement.Type = CharacterType.Minotaur;
        }

        private void OnEnable() {
            //subscribe finish turn event
            GameManager.OnMinotaurMoveTurn += MoveMinotaur;
            
            //subscribe to undo event
            GameManager.OnUndoMovementAction += OnUndoMovement;
        }

        private void OnDisable() {
            //unsubscribe finish turn event
            GameManager.OnMinotaurMoveTurn -= MoveMinotaur;
            
            //unsubscribe to undo event
            GameManager.OnUndoMovementAction -= OnUndoMovement;
        }

        private void MoveMinotaur() {
            var direction = DirectionToMove();
            characterMovement.OnMoveToDirection(direction);
        }

        private void OnUndoMovement() {
            characterMovement.OnUndoMove();       
        }
        
        public bool CheckIfReachedPlayerPosition() {
            if (m_lastTargetPosition != characterMovement.CurrentPosition) return false;
            
            OnMinotaurWins?.Invoke();
            return true;

        }
        
        private Vector2Int DirectionToMove() {
            //get player current pos
            var targetPosition = PlayerController.CurrentPosition();
            m_lastTargetPosition = targetPosition;
            
            var directionX = Vector2Int.zero;
            var directionY = Vector2Int.zero;
            
            //Set the current direction on each axis
            directionX = targetPosition.x > characterMovement.CurrentPosition.x ? Vector2Int.right : Vector2Int.left;
            directionY = targetPosition.y > characterMovement.CurrentPosition.y ? Vector2Int.up : Vector2Int.down;

            //if its the same position in X axis, just move up and down
            if (characterMovement.CurrentPosition.x == targetPosition.x) {
                return directionY;
            }
            
            return !characterMovement.BoxCollisionManager.CanIMoveInDirection(directionX) ? directionY : directionX;
        }
    }
}