using Obstacles;
using UnityEngine;
using Utility;

namespace Decor
{
    public class CenterDecor : MonoBehaviour, IDecor
    {
        public void Generate()
        {
            CommonObjectUtility.GenerateCenter(transform);
        }
    }
}