using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TheseusAndMinotaur.Managers {

    public class LevelManager : MonoBehaviour {

        public Vector2 EndGamePosition;
        [SerializeField] private Tilemap grid;
        
        public Tilemap GetGrid() {
            return grid;
        }
    }
}
