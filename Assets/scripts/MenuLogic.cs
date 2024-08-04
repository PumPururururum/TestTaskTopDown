using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLogic : MonoBehaviour
{
    public TMP_Text scoreText;
    private void Start()
    {
        scoreText.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }


}
