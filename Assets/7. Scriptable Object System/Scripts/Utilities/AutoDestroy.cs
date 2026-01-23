namespace SOSystem
{
    using UnityEngine;
    using UnityEngine.Events;

    public class AutoDestroy : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField][Range(0, 10)] private float lifeTime;

        [Header("Event")]
        [SerializeField] private UnityEvent OnTimeUpAndDestroyHandler;

        private float _timer;
        private void Start()
        {
            _timer = lifeTime;
        }

        private void Update()
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0f)
            {
                Destroy(gameObject);
                OnTimeUpAndDestroyHandler?.Invoke();
            }
        }

    }
}
