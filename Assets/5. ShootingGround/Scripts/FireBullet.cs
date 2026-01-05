using UnityEngine;

namespace ShootingGround
{
    public class FireBullet : MonoBehaviour
    {
        [SerializeField] private LayerMask targetLayerMask;
        float radius = 3.33f / 2;

        void Update()
        {
        
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Debug.DrawRay(ray.origin, ray.direction * 30f, Color.red, 1f);

                if (Physics.Raycast(ray, out hit, 30f, targetLayerMask))
                {
                    int scoreIncrease = CalculateScore(hit.point, hit.collider.bounds.center);
                    //Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red, 1f);
                    Destroy(hit.transform.gameObject);
                    TargetSpawner.Instance.SpawnTarget();
                    TimerUI.Instance.ResetTimer();
                
                    PlayingUI.Instance.ScoreIncrement(scoreIncrease);
                }
            }
        }

        private int CalculateScore(Vector3 hitPoint, Vector3 targetCenter)
        {
            float distanceToCenter = Vector3.Distance(hitPoint, targetCenter);
            float normalizedDistance = distanceToCenter / radius;

            int score = 1;
            if (normalizedDistance <= 1.0f)
            {
                if (normalizedDistance <= 1.0f / 6.0f)
                {
                    score = 10;
                }
                else if (normalizedDistance <= 4.0f / 6.0f)
                {
                    score = 5;
                }
                else 
                {
                    score = 3;
                }
            }
            return score;
        }
    }
}
