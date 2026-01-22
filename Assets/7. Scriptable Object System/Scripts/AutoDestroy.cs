namespace SOSystem
{
    using UnityEngine;

    public class AutoDestroy : MonoBehaviour
    {
        [Header(HeaderNames.Config)]
        [SerializeField][Range(1, 10)] private float lifeTime;

        private void Start()
        {
            Destroy(gameObject, lifeTime);
        }

    }
}
