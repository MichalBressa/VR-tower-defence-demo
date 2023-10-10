using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool gameOver = false;

    public static bool pause = false;

    public GameObject gameOverUI;
    public GameObject pauseUI;

    public TextMeshProUGUI score;



    private void Start()
    {
        gameOver = false;
        pause = false;
    }

    private void Update()
    {
       /* if (Input.GetKeyDown("escape"))
        {
            if (pause == false)
            {
                Debug.Log("Game paused");
                PauseGame();
            }
            else
            {
                ResumeGame();
                Debug.Log("Game resumed ");
            }
            
        }

        */


    }

    public void PauseGame()
    {
        pause = true;
        pauseUI.SetActive(true);
        Time.timeScale = 0f;

    }

    public void ResumeGame()
    {
        pause = false;
        pauseUI.SetActive(false);
        Time.timeScale = 1f;

    }

    public void GameOver()
    {
        gameOver = true;
        gameOverUI.SetActive(true);
        int waves = WaveSpawn.waveNumber - 1;
        score.text = "You survived: " + waves.ToString() + "waves";
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void Menu()
    {
        // go to menu
    }
}
