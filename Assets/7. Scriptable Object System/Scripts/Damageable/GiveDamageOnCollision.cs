
namespace SOSystem
{
    using System;
    using UnityEngine;
    using UnityEngine.Events;

    public class GiveDamageOnCollision : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] private int damage;

        [Header("Event")]
        [SerializeField] private UnityEvent OnGiveDamageSuccessHandler;

        //public event Action OnGiveDamageSuccessAction;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Damageable damageable))
            {
                damageable.TakeDamage(damage);
                OnGiveDamageSuccessHandler?.Invoke();
            }
        }
    }
}
