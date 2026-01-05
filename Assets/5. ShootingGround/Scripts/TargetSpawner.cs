using UnityEngine;

namespace ShootingGround
{
    public class TargetSpawner : MonoBehaviour
    {
        public static TargetSpawner Instance {  get; private set; }

        [SerializeField] private Transform[] wallsArray;
        [SerializeField] private Transform targetPrefab;
        private float xOffset = 10f;
        private float yOffset = 4f;
        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            SpawnTarget();
        }

        public void SpawnTarget()
        {
            int selectedWallIndex = Random.Range(0, wallsArray.Length-1);
            Transform spawnPoint = wallsArray[selectedWallIndex].GetComponent<Wall>().SpawnPoint;
            Transform targetTransform = Instantiate(targetPrefab, spawnPoint);
            targetTransform.localPosition = new Vector3(Random.Range(-xOffset, xOffset), Random.Range(-yOffset, yOffset), 0f);
        }
    }
}
