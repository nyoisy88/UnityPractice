
namespace SOSystem
{
    using System;
    using UnityEngine;

    public class GiveDamageOnCollision : MonoBehaviour
    {
        [Header(HeaderNames.Config)]
        [SerializeField] private int damage;

        //public event Action OnGiveDamageSuccessAction;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Damageable damageable))
            {
                damageable.TakeDamage(damage);
                Destroy(gameObject);
                this.Fire(EventID.OnBulletHit);
            }
        }
    }
}
