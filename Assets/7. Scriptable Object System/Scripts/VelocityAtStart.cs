using BanGa;
using UnityEngine;

namespace SOSystem
{
    public class VelocityAtStart : MonoBehaviour
    {
        [Header(HeaderNames.Reference)]
        [SerializeField] private Rigidbody2D controlRigidbody;

        [Header(HeaderNames.Config)]
        [SerializeField] private Vector2 randomVelocityRange;
        [SerializeField] private Direction direction;

        [Header("Validation")]
        [SerializeField] bool isFailedConfig;

        void OnValidate()
        {
            isFailedConfig = controlRigidbody == null;
        }

        public enum Direction
        {
            Up,
            Right,
            Forward,
        }

        private void Start()
        {
            if (isFailedConfig) return;
            var direction = GetDirectionVectorBasedOnConfig();
            var velo = direction * UnityEngine.Random.Range(randomVelocityRange.x, randomVelocityRange.y);
            controlRigidbody.velocity = velo;
        }

        private Vector3 GetDirectionVectorBasedOnConfig()
        {
            switch (direction)
            {
                case Direction.Up:
                    return transform.up;
                case Direction.Right:
                    return transform.right;
                case Direction.Forward:
                    return transform.forward;
                default:
                    return transform.up;
            }
        }
    }
}
