using UnityEngine;
namespace SOSystem
{
    public class SpawnBulletOnClick : MonoBehaviour
    {
        [Header(HeaderNames.Reference)]
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform gunBarrel;

        [Header(HeaderNames.Config)]
        [SerializeField] private KeyCode fireKey = KeyCode.Mouse0;

        void Update()
        {
            if (Input.GetKeyDown(fireKey))
            {
                GameObject bulletGO = Instantiate(bulletPrefab, gunBarrel.position, Quaternion.identity);
                bulletGO.transform.up = gunBarrel.up;
                this.Fire(EventID.OnPlayerShoot);
            }
        }
    }
}
