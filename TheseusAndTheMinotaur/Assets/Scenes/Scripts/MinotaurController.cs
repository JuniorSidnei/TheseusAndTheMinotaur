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

        public PlayerController PlayerController;
        
        private int m_numberOfMovements = 1;

        public int NumberOfMovements {
            get => m_numberOfMovements;
            set => m_numberOfMovements = value;
        }
        
        private void Awake() {
            CharacterMovement.Type = CharacterType.Minotaur;
            
            //subscribe finish turn event
            GameManager.OnMinotaurMoveTurn += MoveMinotaur;
        }
        
        private void MoveMinotaur() {
            var direction = DirectionToMove();
            CharacterMovement.OnMoveToDirection(direction);
        }
        
        
        private Vector2Int DirectionToMove() {
            //get player current pos
            var targetPosition = PlayerController.CurrentPosition();
            var directionX = Vector2Int.zero;
            var directionY = Vector2Int.zero;
           
            //Set the current direction on each axis
            directionX = targetPosition.x > CharacterMovement.CurrentPosition.x ? Vector2Int.right : Vector2Int.left;
            directionY = targetPosition.y > CharacterMovement.CurrentPosition.y ? Vector2Int.up : Vector2Int.down;

            //if its the same position in X axis, just move up and down
            if (CharacterMovement.CurrentPosition.x == targetPosition.x) {
                return CharacterMovement.BoxCollisionManager.CanIMoveInDirection(Vector2Int.up) ? Vector2Int.up : Vector2Int.down;
            }
            
            return !CharacterMovement.BoxCollisionManager.CanIMoveInDirection(directionX) ? directionY : directionX;
        }
    }
}