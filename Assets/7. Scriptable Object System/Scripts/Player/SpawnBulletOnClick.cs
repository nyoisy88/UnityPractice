using UnityEngine;
using UnityEngine.Events;
namespace SOSystem
{
    public class SpawnBulletOnClick : MonoBehaviour
    {
        [Header("Reference")]
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform gunBarrel;

        [Header("Config")]
        [SerializeField] private KeyCode fireKey = KeyCode.Mouse0;

        [Header("Event")]
        [SerializeField] private IntegerVariableSO shotCountVar;

        void Update()
        {
            if (Input.GetKeyDown(fireKey))
            {
                GameObject bulletGO = Instantiate(bulletPrefab, gunBarrel.position, Quaternion.identity);
                bulletGO.transform.up = gunBarrel.up;
                shotCountVar.Value++;
            }
        }
    }
}
