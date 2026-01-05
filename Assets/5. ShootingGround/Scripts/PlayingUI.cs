using TMPro;
using UnityEngine;

namespace ShootingGround
{
    public class PlayingUI : MonoBehaviour
    {
        public static PlayingUI Instance { get; private set; }
        [SerializeField] private TextMeshProUGUI scoreText;

        private int score = 0;

        private void Awake()
        {
            Instance = this;
        }

        public void ScoreIncrement(int value)
        {
            score += value;
            scoreText.text = score.ToString();
        }
    }
}
