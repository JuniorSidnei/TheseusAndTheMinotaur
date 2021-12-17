using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheseusAndMinotaur.Character {

    public class MinotaurController : CharacterController {
        
        //It he can move one square horizontally and get closer, he will do that.
        //If he can’t move horizontally, then he will try to move vertically.
        //And, most importantly, he will choose a horizontal move before a vertical move.

        public Transform TargetPosition;
        
        private void Start() {
            Invoke("MoveWithDirection", 5);
        }

        private void MoveWithDirection() {
            CharacterMovement.OnMoveToDirection(Vector2Int.left);
        }
    }
}