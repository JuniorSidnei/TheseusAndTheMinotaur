using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using TheseusAndMinotaur.Managers;
using TheseusAndMinotaur.Player;
using UnityEngine;

namespace TheseusAndMinotaur.Character {
    
    public class CharacterController : MonoBehaviour {
        public enum CharacterType {
            Theseus,
            Minotaur
        }
        
        public CharacterMovement characterMovement;
        public int ID;
        public CharacterType CharType;
        
    }
}
