using UnityEngine;
namespace SOSystem
{
    public class AimToMousePosition : MonoBehaviour
    {
        [Header(HeaderNames.Reference)]
        [SerializeField] private Transform gunTransform;

        void Update()
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = gunTransform.transform.position.z;

            Vector3 direction = (mouseWorldPos - gunTransform.transform.position).normalized;
            gunTransform.transform.up = direction;

        }
    }
}
