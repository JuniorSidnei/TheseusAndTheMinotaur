using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheseusAndMinotaur {
    
    public class BoxCollisionManager : MonoBehaviour {

        public LayerMask ObjectLayer;
        public SpriteRenderer SpriteRend;
        
        public bool CanIMoveInDirection(Vector2Int direction) {
            //if it has more than one collider, player cannot move
            return CreateBoxWithDirection(direction) < 1;
        }

        private int CreateBoxWithDirection(Vector2Int direction) {
            //get origin and size based on direction
            var boxOriginAndSize = GetBoxOriginAndSize(direction);
            
            //create the box an return 
            var boxHit = new RaycastHit2D[5];
            var box = Physics2D.BoxCastNonAlloc(boxOriginAndSize.Item1, boxOriginAndSize.Item2, 0, direction, boxHit, 0, ObjectLayer);
            return box;
        }

        private Tuple<Vector2, Vector3> GetBoxOriginAndSize(Vector2Int direction) {
            var boxOrigin = Vector2.zero;
            var boxSize = Vector3.zero;
            var spriteBounds = SpriteRend.bounds;
            
            if (direction == Vector2Int.left) {
                boxOrigin = new Vector2(spriteBounds.min.x, spriteBounds.center.y);
                boxSize = new Vector2(0.5f, spriteBounds.size.y);
            } else if (direction == Vector2Int.right) {
                boxOrigin = new Vector2(spriteBounds.max.x, spriteBounds.center.y);
                boxSize = new Vector2(0.5f, spriteBounds.size.y);
            } else if (direction == Vector2Int.down) {
                boxOrigin = new Vector2(spriteBounds.center.x, spriteBounds.min.y);
                boxSize = new Vector2(spriteBounds.size.x, 0.5f);
            } else if (direction == Vector2Int.up) {
                boxOrigin = new Vector2(spriteBounds.center.x, spriteBounds.max.y);
                boxSize = new Vector2(spriteBounds.size.x, 0.5f);
            }

            return new Tuple<Vector2, Vector3>(boxOrigin, boxSize);
        }
        
        
        private void OnDrawGizmos() {
            var spriteSize = new Vector3(SpriteRend.bounds.size.x, 0.5f);
            Gizmos.DrawWireCube(new Vector2(SpriteRend.bounds.center.x, SpriteRend.bounds.min.y), spriteSize);
        }
    }
}