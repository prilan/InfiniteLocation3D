namespace Chunks
{
    public class Chunk : IChunk
    {
        public (int, int) Position;

        public void SetPosition(int x, int z)
        {
            Position.Item1 = x;
            Position.Item2 = z;
        }
        
        public void Generate(ChunkObject chunkObject)
        {
            chunkObject.CreateObjects();
        }
    }
}