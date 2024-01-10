using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public AudioManger audioManager;
    public GameObject UIscore;
    public int HighScorePref;


    public void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManger>();
        HighScorePref = PlayerPrefs.GetInt("High Score");
        UIscore.GetComponent<Text>().text = "High Score: " + PlayerPrefs.GetInt("High Score");
    }

    [ContextMenu("Increase Score")]
    public void addScore()
    {
        audioManager.PlaySFX(audioManager.scoreup);
        playerScore += 1;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        if (playerScore > HighScorePref)
        {
            HighScorePref = playerScore;
            PlayerPrefs.SetInt("High Score", HighScorePref);
            UIscore.GetComponent<Text>().text = "High Score: " + HighScorePref;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);

        if (playerScore > HighScorePref)
        {
            HighScorePref = playerScore;
            PlayerPrefs.SetInt("High Score", HighScorePref);
            UIscore.GetComponent<Text>().text = "High Score: " + playerScore;
        }
    }

    public void backToMenu()
    {
        SceneManager.LoadScene(0);
    }

}
