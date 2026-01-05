using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ShootingGround
{
    public class TimerUI : MonoBehaviour
    {
        public static TimerUI Instance { get; private set; }
        [SerializeField] private Image timerImage;

        private float playingTimer;
        private float playingTimerMax = 3f;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            timerImage.fillAmount = 1f;
            playingTimer = playingTimerMax;
        }

        private void Update()
        {
            playingTimer -= Time.deltaTime;
            timerImage.fillAmount = playingTimer / playingTimerMax;
            if(playingTimer < 0)
            {
                SceneManager.LoadScene("ShootingGround");
            }
        }

        public void ResetTimer()
        {
            playingTimer = playingTimerMax;
        }
    }
}
