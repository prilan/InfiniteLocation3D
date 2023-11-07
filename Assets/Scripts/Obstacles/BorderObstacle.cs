using UnityEngine;
using Random = System.Random;

namespace Obstacles
{
    /// <summary>
    /// Obstacle on border of chunk. For example wall
    /// </summary>
    public class BorderObstacle : AbstractObstacle
    {
        [Range(0f, 1f)]
        public float Probability;

        private Random random = new Random();

        public void Generate(int index, Transform root)
        {
            if (random.NextDouble() < 1 - Probability) return;

            float x = 0;
            float z = 0;
            float rotY = 0;
            switch (index) {
                case 0:
                    x = 5;
                    z = 0;
                    rotY = 90;
                    break;
                case 1:
                    x = 0;
                    z = 5;
                    rotY = 0;
                    break;
                case 2:
                    x = -5;
                    z = 0;
                    rotY = 90;
                    break;
                case 3:
                    x = 0;
                    z = -5;
                    rotY = 0;
                    break;
            }
            var wallObject = Instantiate(this, root);
            var objTransform = wallObject.transform;
            var objPosition = objTransform.localPosition;
            var objRotation = objTransform.localEulerAngles;
            objPosition.x = x;
            objPosition.z = z;
            objRotation.y = rotY;
            objTransform.localPosition = objPosition;
            objTransform.localEulerAngles = objRotation;
        }
    }
}