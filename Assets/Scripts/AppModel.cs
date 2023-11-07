using System.Collections.Generic;
using System.Linq;
using Chunks;
using Utility;

namespace InfiniteLocation3D
{
    /// <summary>
    /// Application model with runtime data
    /// </summary>
    public class AppModel : AbstractSingleton<AppModel>
    {
        public (int, int) PlayerPosition = (0, 0);
        
        private readonly Dictionary<(int, int), ChunkObject> mapChunksDict = new();

        public void Initialize()
        {
            PlayerPosition = (0, 0);
            mapChunksDict.Clear();
        }
        
        public void SetPlayerPosition(int x, int z)
        {
            PlayerPosition = (x, z);
        }
        
        public void MapChunkCreate(int x, int z, ChunkObject chunkObject)
        {
            mapChunksDict[(x, z)] = chunkObject;
        }

        public bool HasMapChunk(int x, int z)
        {
            return mapChunksDict.ContainsKey((x, z));
        }

        public bool HasMapChunk(ChunkObject chunkObject)
        {
            return mapChunksDict.ContainsValue(chunkObject);
        }

        public (int, int) GetPositionOfChunk(ChunkObject chunkObject)
        {
            return mapChunksDict.FirstOrDefault(map => map.Value.Equals(chunkObject)).Key;
        }
    }
}
