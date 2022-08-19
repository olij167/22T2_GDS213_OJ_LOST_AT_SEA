using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    [SerializeField] private Light directionalLight;
    [SerializeField] private LightingPreset preset;
    [SerializeField, Range(0, 24)] private float timeOfDay;
    [SerializeField] private float timeMultiplier;

    public ActionBasedController leftControl, rightControl;

    //public delegate void SpawnSharkAction(int numToSpawn, SpawnSharks spawner);

    //public static event SpawnSharkAction onSpawnShark;
    public GameObject shark;

    public List<GameObject> spawnerList;

    public int dawnSharksToSpawn = 1, middaySharksToSpawn = 1, duskSharksToSpawn = 3, midnightSharksToSpawn = 2;

    public int currentHour, sharkCount, maxSharks;
    public bool spawnSharks;

    private void Start()
    {
        foreach(GameObject spawner in GameObject.FindGameObjectsWithTag("Spawner"))
        {
            if (!spawnerList.Contains(spawner))
                spawnerList.Add(spawner);
        }
    }

    //public static void AddListener(LightingManager.SpawnSharkAction method)
    //{
    //    LightingManager.onSpawnShark += method;
    //}
    
    //public static void RemoveListener(LightingManager.SpawnSharkAction method)
    //{
    //    LightingManager.onSpawnShark -= method;
    //}

    private void Update()
    {
        if (preset == null)
        {
            return;
        }

        if (Application.isPlaying)
        {
            timeOfDay += Time.deltaTime * timeMultiplier;
            timeOfDay %= 24;
            UpdateLighting(timeOfDay / 24f);

            //Debug.Log("Time = " + timeOfDay / 24);

            //if (timeOfDay >= 18f && timeOfDay <= 18.2f)
            //{
            //    onSpawnShark();
            //}
            currentHour = (int)timeOfDay;
            sharkCount = GameObject.FindGameObjectsWithTag("Shark").Length;
            if (!spawnSharks && sharkCount < maxSharks)
            {
                switch (currentHour)
                {
                    case 6:
                        {
                            SpawnShark(dawnSharksToSpawn);
                            spawnSharks = true;
                            return;
                        }

                    case 12:
                        {

                            SpawnShark(middaySharksToSpawn);
                            spawnSharks = true;
                            break;
                        }

                    case 18:
                        {

                            SpawnShark(duskSharksToSpawn);

                            spawnSharks = true;
                            break;
                        }

                    case 0:
                        {

                            SpawnShark(middaySharksToSpawn);

                            spawnSharks = true;
                            break;
                        }
                }
            }
            else
            {
                switch (currentHour)
                {

                    case 7:
                        {
                            spawnSharks = false;
                            break;
                        }

                    case 13:
                        {
                            spawnSharks = false;
                            break;
                        }

                    case 19:
                        {
                            spawnSharks = false;
                            break;
                        }

                    case 1:
                        {
                            spawnSharks = false;
                            break;
                        }
                }
            }
        }
    }

    void SpawnShark(int numToSpawn)
    {
        int rand = Random.Range(0, spawnerList.Count);
        if ((numToSpawn + sharkCount) < 8)
        {
            for (int i = 0; i < numToSpawn; i++)
            {
                GameObject newShark = Instantiate(shark, spawnerList[rand].transform.position, Quaternion.identity);
                newShark.GetComponent<OarCollision>().leftControl = leftControl;
                newShark.GetComponent<OarCollision>().rightControl = rightControl;

            }
        }
        else
        {
            for (int i = 0; i < 8 - sharkCount; i++)
            {
                Instantiate(shark, spawnerList[rand].transform.position, Quaternion.identity);

            }
        }

    }

    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = preset.ambientColour.Evaluate(timePercent);
        RenderSettings.fogColor = preset.fogColour.Evaluate(timePercent);

        if (directionalLight != null)
        {
            directionalLight.color = preset.directionalColour.Evaluate(timePercent);
            directionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360) - 90f, 170f, 0));
        }
    }

    private void OnValidate()
    {
        if (directionalLight != null)
            return;

        if (RenderSettings.sun != null)
        {
            directionalLight = RenderSettings.sun;
        }
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();

            foreach(Light light in lights)
            {
                directionalLight = light;
                return;
            }
        }
    }
}
