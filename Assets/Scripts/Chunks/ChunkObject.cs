using Decor;
using Obstacles;
using UnityEngine;
using Random = System.Random;

namespace Chunks
{
    /// <summary>
    /// Map chunk generating
    /// </summary>
    public class ChunkObject : MonoBehaviour
    {
        public static readonly float Size = 10;
        
        [Header("Max count of objects")]
        [Range(0, 10)]
        public int MaxTree;
        [Range(0, 10)]
        public int MaxStone;
        [Range(0, 50)]
        public int MaxGrass;
        [Range(0, 20)]
        public int MaxFlower;
        
        [Header("Chunk data class")]
        public Chunk Chunk;
        
        [Header("Objects on map chunk")]
        public CenterObstacle TreeObstacle;
        public CenterObstacle Tree2Obstacle;
        public BorderObstacle WallObstacle;
        public CenterObstacle StoneObstacle;
        
        public CenterDecor GrassDecor;
        public CenterDecor FlowerDecor;
        
        private Random random = new Random();

        private void Awake()
        {
            Chunk = new Chunk();
        }

        /// <summary>
        /// Create and set all the objects
        /// </summary>
        public void CreateObjects()
        {
            CreateCenterObstacles(TreeObstacle, MaxTree);
            CreateCenterObstacles(Tree2Obstacle, MaxTree);
            CreateCenterObstacles(StoneObstacle, MaxStone);
            
            CreateCenterDecors(GrassDecor, MaxGrass);
            CreateCenterDecors(FlowerDecor, MaxFlower);
            
            var wallCount = 4;
            for (int index = 0; index < wallCount; index++) {
                WallObstacle.Generate(index, transform);
            }
        }

        
        /// <summary>
        /// Generates obstacles
        /// </summary>
        /// <param name="centerObstacle">Obstacle prefab</param>
        /// <param name="maxCount">Max count for creating</param>
        private void CreateCenterObstacles(CenterObstacle centerObstacle, int maxCount)
        {
            var count = random.Next(0, maxCount + 1);
            for (int index = 0; index < count; index++) {
                var treeObject = Instantiate(centerObstacle, transform);
                treeObject.Generate();
            }
        }
        
        /// <summary>
        /// Generates decor objects
        /// </summary>
        /// <param name="centerDecor">Decor prefab</param>
        /// <param name="maxCount">Max count for creating</param>
        private void CreateCenterDecors(CenterDecor centerDecor, int maxCount)
        {
            var count = random.Next(0, maxCount + 1);
            for (int index = 0; index < count; index++) {
                var treeObject = Instantiate(centerDecor, transform);
                treeObject.Generate();
            }
        }
    }
}
