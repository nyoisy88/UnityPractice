using UnityEngine;

namespace ShootingGround
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private LayerMask groundMask;
        private float gravity = -9.81f * 2;
    
        private Vector3 velocity;

        private CharacterController characterController;
        private float moveSpeed;
        private float moveSpeedMax = 12f;
        private float sphereRadius = 0.4f;
        private float jumpHeight = 3f;
        private bool isGrounded;

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();

            moveSpeed = moveSpeedMax;
        }

        private void Start()
        {
            PauseUI.Instance.OnSpeedChanged += Instance_OnSpeedChanged;
        }

        private void Instance_OnSpeedChanged(float value)
        {
            moveSpeed = value * moveSpeedMax;
        }

        void Update()
        {
            isGrounded = Physics.CheckSphere(transform.position, sphereRadius, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }
            else
            {
                velocity.y += gravity * Time.deltaTime;
            }
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 moveDir = transform.right * x + transform.forward * z;

            characterController.Move(moveDir * moveSpeed * Time.deltaTime);
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            characterController.Move(velocity * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseUI.Instance.Show();
            }
        }
    }
}
