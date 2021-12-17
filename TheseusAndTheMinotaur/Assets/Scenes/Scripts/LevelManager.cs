using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TheseusAndMinotaur.Managers {

    public class LevelManager : MonoBehaviour {

        [SerializeField] private Tilemap grid;
        
        public Tilemap GetGrid() {
            return grid;
        }
    }
}
