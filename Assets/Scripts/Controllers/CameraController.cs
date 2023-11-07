using UnityEngine;

namespace Controllers
{
    /// <summary>
    /// Control of camera coordinates
    /// </summary>
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Camera camera;
        [SerializeField] private PlayerController player;

        private Vector3 initPosition;

        private void Awake()
        {
            initPosition = camera.transform.localPosition;
        }

        /// <summary>
        /// Updates camera position following the player
        /// </summary>
        private void Update()
        {
            var newPosition = initPosition;
            newPosition.x += player.transform.localPosition.x;
            newPosition.z += player.transform.localPosition.z;
            camera.transform.localPosition = newPosition;
        }
    }
}