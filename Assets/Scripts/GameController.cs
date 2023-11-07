using System.Collections.Generic;
using Chunks;
using Controllers;
using UnityEngine;

namespace InfiniteLocation3D
{
    /// <summary>
    /// Control of game behaviour
    /// </summary>
    public class GameController : MonoBehaviour
    {
        [SerializeField] private Transform root;
        [SerializeField] private ChunkObject chunkObject;
        [SerializeField] private PlayerController playerController;

        /// <summary>
        /// Shift positions for generating chunks around player
        /// </summary>
        private List<(int, int)> aroundPositionList = new List<(int, int)>()
        {
            (0, 0),
            (1, 0),
            (1, -1),
            (0, -1),
            (-1, -1),
            (-1, 0),
            (-1, 1),
            (0, 1),
            (1, 1),
        };
        
        private void Awake()
        {
            playerController.OnPositionChanged += OnPlayerPositionChanged;
            
            AppModel.Instance.Initialize();

            GenerateChunks();
        }

        private void OnDestroy()
        {
            playerController.OnPositionChanged -= OnPlayerPositionChanged;
        }

        private void OnPlayerPositionChanged()
        {
            GenerateChunks();
        }

        /// <summary>
        /// Generates map chunks according shift positions
        /// </summary>
        private void GenerateChunks()
        {
            var playerPosition = AppModel.Instance.PlayerPosition;

            foreach (var pair in aroundPositionList) {
                var position = (playerPosition.Item1 + pair.Item1, playerPosition.Item2 + pair.Item2);
                if (AppModel.Instance.HasMapChunk(position.Item1, position.Item2)) continue;
                CreateChunk(position.Item1, position.Item2);
            }
        }

        /// <summary>
        /// Instantiate chunk and add every random objects on it
        /// </summary>
        /// <param name="x">Horizontal surface coordinate x</param>
        /// <param name="z">Horizontal surface coordinate z</param>
        private void CreateChunk(int x, int z)
        {
            var chunkTransform = chunkObject.transform;
            var position = chunkTransform.position;
            var localScale = chunkTransform.localScale;
            
            position.x = ChunkObject.Size * localScale.x * x;
            position.z = ChunkObject.Size * localScale.z * z;
            
            var newChunk = Instantiate(chunkObject, root);
            newChunk.transform.position = position;
            
            SetNewChunk(x, z, newChunk);
        }

        private static void SetNewChunk(int x, int z, ChunkObject newChunk)
        {
            newChunk.Chunk.SetPosition(x, z);
            newChunk.Chunk.Generate(newChunk);

            AppModel.Instance.MapChunkCreate(x, z, newChunk);
        }
    }
}
