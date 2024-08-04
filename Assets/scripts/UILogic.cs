using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILogic : MonoBehaviour
{

    public TMP_Text scoreText;
    public TMP_Text endScore;
    private int currentScore;

    public GameObject gameOverScreen;
    public GameObject highScoreText;
    public void OpenMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void AddScore(int score)
    {
        currentScore = currentScore + score;
        scoreText.text = currentScore.ToString();
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        endScore.text = currentScore.ToString();    
        if (currentScore > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", currentScore);
            highScoreText.SetActive(true);
        }

    }
}
