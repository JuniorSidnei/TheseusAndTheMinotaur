using System;
using System.Collections;
using System.Collections.Generic;
using TheseusAndMinotaur.Managers;
using UnityEngine;

namespace TheseusAndMinotaur.Character {

    public class PlayerController : CharacterController {

        private void Awake() {
            characterMovement.Type = CharacterType.Theseus;
        }

        private void OnEnable() {
            //subscribe the input event with values
            GameManager.OnMoveToDirection += OnMoveToDirection;

            //subscribe to undo event
            GameManager.OnUndoMovementAction += OnUndoMovement;
        }

        private void OnDisable() {
            //unsubscribe the input event with values
            GameManager.OnMoveToDirection -= OnMoveToDirection;

            //unsubscribe to undo event
            GameManager.OnUndoMovementAction -= OnUndoMovement;
        }

        private void OnMoveToDirection(Vector2Int direction) {
            if (GameManager.Instance.GetCurrentTurn() == GameManager.CharacterTurn.MinotaurTurn) return;
            
            characterMovement.OnMoveToDirection(direction);
        }

        private void OnUndoMovement() {
            characterMovement.OnUndoMove();       
        }
        
        public Vector2Int CurrentPosition() {
            return characterMovement.CurrentPosition;
        }
    }
}
