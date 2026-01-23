using System;
using UnityEngine;
using UnityEngine.Events;
namespace SOSystem
{
    public class Damageable : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] private int baseHealth;

        [Header("Expose Current HP")]
        [SerializeField] private int currentHealth;

        [Header("Event")]
        [SerializeField] private UnityEvent OnOutOfHPHandler;

        private void Start()
        {
            currentHealth = baseHealth;
        }
        public void TakeDamage(int damage)
        {
            if (damage >= currentHealth)
            {
                currentHealth = 0;
                OnOutOfHPHandler?.Invoke();
            }
            currentHealth -= damage;
        }
    }
}
