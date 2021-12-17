using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using TheseusAndMinotaur.Player;
using UnityEngine;

namespace TheseusAndMinotaur.Character {
    
    public class CharacterController : MonoBehaviour {
        public enum CharacterType {
            Theseus,
            Minotaur
        }
        
        public CharacterMovement CharacterMovement;
        public int ID;
        public CharacterType CharType;
    }
}
