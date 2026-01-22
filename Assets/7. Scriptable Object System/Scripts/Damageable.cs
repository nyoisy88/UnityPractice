using System;
using UnityEngine;
namespace SOSystem
{
    public class Damageable : MonoBehaviour
    {
        [Header(HeaderNames.Config)]
        [SerializeField] private int baseHealth;

        [Header("Expose Current HP")]
        [SerializeField] private int currentHealth;

        //public event Action OnOutOfHPAction;

        private void Start()
        {
            currentHealth = baseHealth;
        }
        public void TakeDamage(int damage)
        {
            if (damage >= currentHealth)
            {
                currentHealth = 0;
                Destroy(gameObject);
                this.Fire(EventID.OnHelicopterDead);
            }
            currentHealth -= damage;
        }
    }
}
