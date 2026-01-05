using UnityEngine;

namespace ShootingGround
{
    public class Wall : MonoBehaviour
    {
        [SerializeField] private Transform spawnPoint;

        public Transform SpawnPoint { get => spawnPoint; }
    }
}
