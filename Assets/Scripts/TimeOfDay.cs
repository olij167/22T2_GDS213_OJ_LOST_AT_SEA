using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOfDay : MonoBehaviour
{
    public float timeMultiplier;

    public float currentTimeHours, currentTimeMinutes, currentTimeSeconds;

    //public bool isDayTime;

    void Update()
    {
        currentTimeSeconds += Time.deltaTime * timeMultiplier;

        if (currentTimeSeconds >= 60f)
        {
            currentTimeMinutes += 1;
            currentTimeSeconds = 0f;
        }

        if (currentTimeMinutes >= 60f)
        {
            currentTimeHours += 1;
            currentTimeMinutes = 0f;

            if (currentTimeHours >= 24)
            {
                currentTimeHours = 0f;
            }
        }

        
    }

    
}
