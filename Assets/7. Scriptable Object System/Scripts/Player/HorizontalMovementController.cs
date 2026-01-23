using UnityEngine;
namespace SOSystem
{
    public class HorizontalMovementController : MonoBehaviour
    {
        [Header("Reference")]
        [SerializeField] private Rigidbody2D controlRigid;

        [Header("Config")]
        [SerializeField] private int maxSpeed;
        [SerializeField] private int acceleration;
        [SerializeField] private KeyCode moveLeftKey;
        [SerializeField] private KeyCode moveRightKey;


        private void Update()
        {
            Vector2 inputVector = Vector2.zero;
            if (Input.GetKey(moveLeftKey))
            {
                inputVector.x -= 1;
            }
            if (Input.GetKey(moveRightKey))
            {
                inputVector.x += 1;
            }
            Vector3 moveDir = inputVector.normalized;
            controlRigid.MovePosition(transform.position + moveDir * maxSpeed * Time.deltaTime);
        }

    }
}
