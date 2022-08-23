using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private LightingManager lightingManager;

    [SerializeField] private GameObject startMenu;

    [SerializeField] private bool gameStarted;

    private float timeMultiplierDefault;

    private void Start()
    {
        timeMultiplierDefault = lightingManager.timeMultiplier;

        lightingManager.timeMultiplier = 0;
    }

    public void StartButton()
    {
        if (!gameStarted)
        {
            lightingManager.timeMultiplier = timeMultiplierDefault;
            startMenu.SetActive(false);
            gameStarted = true;
        }
    }
}
