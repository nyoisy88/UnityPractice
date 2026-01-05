using UnityEngine;

namespace ShootingGround
{
    public class MouseLook : MonoBehaviour
    {
        [SerializeField] private Transform playerBody;
        private float mouseSensitivity;
        private float mouseSensitivityMax = 200f;

        private float xRotation = 0f;

        public float MouseSensitivity { get => mouseSensitivity; set => mouseSensitivity = value; }

        private void Awake()
        {
            mouseSensitivity = mouseSensitivityMax;
            Cursor.lockState = CursorLockMode.Locked; 
        }
        void Start()
        {
            PauseUI.Instance.OnSensChanged += Instance_OnSensChanged;
        }

        private void Instance_OnSensChanged(float value)
        {
            mouseSensitivity = value * mouseSensitivityMax;
        }

        void Update()
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
            xRotation -= mouseY;

            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);    
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
