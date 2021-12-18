using System.Collections;
using System.Collections.Generic;
using TheseusAndMinotaur.Managers;
using UnityEngine;

namespace TheseusAndMinotaur.Character {

    public class PlayerController : CharacterController {

        
        public delegate void OnPlayerWin();
        public static event OnPlayerWin OnPlayerWins;
        
        private void Awake() {
            //subscribe the input event with values
            GameManager.OnMoveToDirection += OnMoveToDirection;
            CharacterMovement.Type = CharacterType.Theseus;
        }

        private void OnMoveToDirection(Vector2Int direction) {
            if (GameManager.Instance.GetCurrentTurn() == GameManager.CharacterTurn.MinotaurTurn) return;
            
            CharacterMovement.OnMoveToDirection(direction);
        }

        public Vector2Int CurrentPosition() {
            return CharacterMovement.CurrentPosition;
        }
    }
}
