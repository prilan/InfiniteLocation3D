using UnityEngine;

namespace Obstacles
{
    public abstract class AbstractObstacle : MonoBehaviour, IObstacle
    {
        public virtual void Generate()
        {
        }
    }
}
