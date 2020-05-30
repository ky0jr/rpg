using UnityEngine;

namespace RPG.Game.Camera
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField]
        private float smoothSpeed = 0.125f;

        [SerializeField] private Vector3 offset;

        [SerializeField] private Transform target;

        private void Start()
        {
            transform.position = target.position + offset;
        }

        void FixedUpdate()
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
