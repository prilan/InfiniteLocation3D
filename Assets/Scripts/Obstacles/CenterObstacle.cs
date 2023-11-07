using Utility;

namespace Obstacles
{
    /// <summary>
    /// Obstacle on center of the chunk randomly distributed
    /// </summary>
    public class CenterObstacle : AbstractObstacle
    {
        public override void Generate()
        {
            base.Generate();
            
            CommonObjectUtility.GenerateCenter(transform);
        }
    }
}
