using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private LightingManager lightingManager;

    [SerializeField] private GameObject startMenu, endMenu;
    [SerializeField] private Motor motor;

    [SerializeField] private bool gameStarted, gameOver;

    private float timeMultiplierDefault;

    [SerializeField] private float gameTimer;

    [SerializeField] private TextMeshProUGUI endText, endGameTimerText;

    private void Start()
    {
        timeMultiplierDefault = lightingManager.timeMultiplier;

        lightingManager.timeMultiplier = 0;

        motor.enabled = false;
        endMenu.SetActive(false);
        startMenu.SetActive(true);

    }

    public void Update()
    {
        if (gameStarted && !gameOver)
        {
            gameTimer += Time.deltaTime;
        }
    }

    public void StartButton()
    {
        if (!gameStarted)
        {
            lightingManager.timeMultiplier = timeMultiplierDefault;
            startMenu.SetActive(false);
            motor.enabled = true;
            gameStarted = true;
        }
    }

    public void WinUI()
    {
        if (!gameOver)
        {
            lightingManager.timeMultiplier = 0;

            Time.timeScale = 0f;

            motor.enabled = false;

            endMenu.SetActive(true);

            endText.text = "You \n survived!";
            
            DisplayTime(gameTimer, endGameTimerText);

            gameOver = true;
        }
    }

    public void LoseUI()
    {
        if (!gameOver)
        {
            lightingManager.timeMultiplier = 0;

            Time.timeScale = 0f;

            motor.enabled = false;

            endMenu.SetActive(true);

            endText.text = "You are \n dead.";

            DisplayTime(gameTimer, endGameTimerText);

            gameOver = true;
        }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }

    public void TutorialButton(TextMeshProUGUI buttonText)
    {
        buttonText.text = "Not yet added";
    }

    void DisplayTime(float timeToDisplay, TextMeshProUGUI timeText)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliSeconds = (timeToDisplay % 1) * 1000;
        timeText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliSeconds);
    }
}
