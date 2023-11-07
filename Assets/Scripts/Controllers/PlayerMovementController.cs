using UnityEngine;

namespace Controllers
{
    /// <summary>
    /// Control force of Player rigidbody movement 
    /// </summary>
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] Rigidbody rigidbody;
        [SerializeField] private float force = 3000f;
        
        private void Update()
        {
            if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow)) {
                rigidbody.AddForce(0, 0, force * Time.deltaTime);
            }
            if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow)) {
                rigidbody.AddForce(- force * Time.deltaTime, 0, 0);

            }
            if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow)) {
                rigidbody.AddForce(0, 0, - force * Time.deltaTime);
            }
            if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow)) {
                rigidbody.AddForce(force * Time.deltaTime, 0, 0);
            }
        }
    }
}
