using System.Collections;
using System.Collections.Generic;
using TheseusAndMinotaur.Managers;
using UnityEngine;

namespace TheseusAndMinotaur.Character {

    public class PlayerController : CharacterController {

        private void Start() {
            //subscribe the input event with values
            GameManager.OnMoveToDirection += OnMoveToDirection;
        }

        private void OnMoveToDirection(Vector2Int direction) {
            CharacterMovement.OnMoveToDirection(direction);
        }
    }
}
