using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HitNRunManager : MonoBehaviour
{
    public static HitNRunManager Instance { get; private set; }
    public const string HIGH_SCORE = "HIGH_SCORE";

    [SerializeField] private TextMeshProUGUI scoreText;
    private int score = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void IncrementScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
        int bestScore = PlayerPrefs.GetInt(HIGH_SCORE, 0);
        if (score > bestScore)
        {
            PlayerPrefs.SetInt(HIGH_SCORE, score);
        }
    }
}
