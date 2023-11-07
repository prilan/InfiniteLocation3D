using System;
using Chunks;
using InfiniteLocation3D;
using UnityEngine;

namespace Controllers
{
    /// <summary>
    /// Control player position on chunks
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        public event Action OnPositionChanged = () => { };

        private void Update()
        {
            ProcessNextChunkSurface();
        }

        /// <summary>
        /// Set next chunk for player
        /// </summary>
        private void ProcessNextChunkSurface()
        {
            int SURFACE_LAYER_ID = 7;
            int surfaceLayerMask = (1 << SURFACE_LAYER_ID);

            bool isOnSurface = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out RaycastHit hit, 10f, surfaceLayerMask);

            if (!isOnSurface) return;
            
            var chunk = hit.collider.gameObject.GetComponent<ChunkObject>();
            if (!AppModel.Instance.HasMapChunk(chunk)) return;
            
            var position = AppModel.Instance.GetPositionOfChunk(chunk);
            if (position == AppModel.Instance.PlayerPosition) return;
            
            AppModel.Instance.SetPlayerPosition(position.Item1, position.Item2);
            OnPositionChanged();
        }
    }
}
