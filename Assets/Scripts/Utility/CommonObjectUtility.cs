using Chunks;
using UnityEngine;
using Random = System.Random;

namespace Utility
{
    /// <summary>
    /// Utility class for common actions
    /// </summary>
    public static class CommonObjectUtility
    {
        private static Random random = new Random();
        
        public static void GenerateCenter(Transform transform)
        {
            var x = ((float)random.NextDouble() - 0.5f) * ChunkObject.Size;
            var z = ((float)random.NextDouble() - 0.5f) * ChunkObject.Size;
            var objTransform = transform;
            var objPosition = objTransform.localPosition;
            objPosition.x = x;
            objPosition.z = z;
            objTransform.localPosition = objPosition;
        }
    }
}
