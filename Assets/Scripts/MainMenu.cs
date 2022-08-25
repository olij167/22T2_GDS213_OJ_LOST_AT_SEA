using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private LightingManager lightingManager;

    [SerializeField] private GameObject startMenu, endMenu, tutorial1, tutorial2, tutorial3, tutorial4;
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
        tutorial1.SetActive(false);
        tutorial2.SetActive(false);
        tutorial3.SetActive(false);
        tutorial4.SetActive(false);
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
            tutorial1.SetActive(false);
            tutorial2.SetActive(false);
            tutorial3.SetActive(false);
            tutorial4.SetActive(false);
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

            endText.text = "You are \n shark bait.";

            DisplayTime(gameTimer, endGameTimerText);

            gameOver = true;
        }
    }

    public void RestartButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        
    }

    public void TutorialButton()
    {
        startMenu.SetActive(false);
        tutorial1.SetActive(true);
    }
    
    public void Next1()
    {
        tutorial1.SetActive(false);
        tutorial2.SetActive(true);
    }

    public void Next2()
    {
        tutorial2.SetActive(false);
        tutorial3.SetActive(true);
    }
    
    public void Next3()
    {
        tutorial3.SetActive(false);
        tutorial4.SetActive(true);
    }
    
    public void Previous1()
    {
        startMenu.SetActive(true);
        tutorial1.SetActive(false);
    }
    
    public void Previous2()
    {
        tutorial1.SetActive(true);
        tutorial2.SetActive(false);
    }
    
    public void Previous3()
    {
        tutorial2.SetActive(true);
        tutorial3.SetActive(false);
    }
    
    public void Previous4()
    {
        tutorial3.SetActive(true);
        tutorial4.SetActive(false);
    }


    void DisplayTime(float timeToDisplay, TextMeshProUGUI timeText)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliSeconds = (timeToDisplay % 1) * 1000;
        timeText.text = "It took \n" + string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliSeconds);
    }
}
