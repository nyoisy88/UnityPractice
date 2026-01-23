using UnityEngine;
using UnityEngine.Events;
namespace SOSystem
{
    public class SpawnObjectWithInterval : MonoBehaviour
    {
        #region Init, config
        [Header("Config")]
        [SerializeField] GameObject prefab;
        [SerializeField] Vector2 randomIntervalRange;
        [SerializeField] float randomYRange;

        [Header("Event")]
        [SerializeField] private IntegerVariableSO spawnedObjectCountVar;

        [Header("Validation")]
        [SerializeField] bool isFailedConfig;
        void OnValidate()
        {
            isFailedConfig = prefab == null;
        }

        void OnEnable()
        {
            if (isFailedConfig)
            {
                enabled = false;
            }
        }
        #endregion//init, config

        private float _spawnTimer;

        private void Update()
        {
            _spawnTimer -= Time.deltaTime;
            if (_spawnTimer < 0f)
            {
                _spawnTimer = UnityEngine.Random.Range(randomIntervalRange.x, randomIntervalRange.y);
                SpawnObject();
            }
        }

        private void SpawnObject()
        {
            GameObject spawnGO = Instantiate(prefab);
            var spawnPos = transform.position;
            spawnPos.y += UnityEngine.Random.Range(-randomYRange, randomYRange);
            spawnGO.transform.position = spawnPos;
            spawnedObjectCountVar.Value++;
        }
    }
}
