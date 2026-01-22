using UnityEngine;
namespace SOSystem
{
    public class SpawnObjectRequester : MonoBehaviour
    {
        #region Init, config
        [Header("Config")]
        [SerializeField] GameObject prefab;

        [Header("Validation")]
        [SerializeField] bool isFailedConfig;

        void OnValidate()
        {
            isFailedConfig = prefab == null;
        }
        #endregion//init, config

        #region Public
        public void In_SpawnObject()
        {
            if (isFailedConfig)
            {
                Debug.LogError("Missing prefab!!");
                return;
            }
            var instance = Instantiate(prefab).transform;
            instance.position = transform.position;
        }
        #endregion//Public
    }
}
