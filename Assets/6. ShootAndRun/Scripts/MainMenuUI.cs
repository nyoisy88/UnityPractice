using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public const string HIGH_SCORE = "SHOOT_AND_RUN_HIGH_SCORE";

    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private TextMeshProUGUI highScoreText;

    private void Start()
    {
        playButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("ShootAndRun");
        });
        quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
        int score = PlayerPrefs.GetInt(HIGH_SCORE, 0);
        highScoreText.text = "Best Score: "+ score.ToString(); 
    }
}
