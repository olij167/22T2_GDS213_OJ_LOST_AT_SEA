using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private LightingManager lightingManager;

    [SerializeField] private GameObject startMenu;
    [SerializeField] private Motor motor;

    [SerializeField] private bool gameStarted;

    private float timeMultiplierDefault;

    private void Start()
    {
        timeMultiplierDefault = lightingManager.timeMultiplier;

        lightingManager.timeMultiplier = 0;

        motor.enabled = false;
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
}
