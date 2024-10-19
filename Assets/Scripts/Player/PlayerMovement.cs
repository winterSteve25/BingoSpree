using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private static PlayerMovement _instance;
        public static PlayerMovement Instance => _instance;

        public float moveSpeed;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private Animator animator;
        [SerializeField] private Transform playerLoc;
        
        private Vector2 _moveDirection;

        private void Awake()
        {
            _instance = this;
        }

        private void Update()
        {
            playerLoc.position = transform.position;
        }

        private void FixedUpdate()
        {
            rb.linearVelocity = new Vector3(_moveDirection.x * moveSpeed, 0, _moveDirection.y * moveSpeed);
        }

        private void ProcessInputs(int x, int y)
        {
            // _moveDirection = new Vector2(x, y).normalized;
            //
            // if (_moveDirection.sqrMagnitude == 0) return;
            // if (Mathf.Abs(_moveDirection.y) > 0 && Mathf.Abs(_moveDirection.x) > 0)
            // {
            //     transform.DORotateQuaternion(
            //         Quaternion.Euler(0, 0,
            //             Mathf.Rad2Deg * Mathf.Atan2(Mathf.Abs(_moveDirection.y),
            //                 _moveDirection.y < 0 ? -_moveDirection.x : _moveDirection.x) - 90),
            //         0.2f);
            // }
            // else if (_moveDirection.y < 0 && Mathf.Abs(_moveDirection.x) > 0)
            // {
            //     transform.DORotateQuaternion(Quaternion.Euler(0, 0, 90), 0.2f);
            // }
            // else if (_moveDirection.x < 0 && Mathf.Abs(_moveDirection.y) < 0.0001)
            // {
            //     transform.DORotateQuaternion(Quaternion.Euler(0, 180, 0), 0.2f);
            // }
            // else
            // {
            //     transform.DORotateQuaternion(Quaternion.Euler(0, 0, 0), 0.2f);
            // }
        }
    }
}