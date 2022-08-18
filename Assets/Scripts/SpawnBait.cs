using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBait : MonoBehaviour
{
    public delegate void SpawnBaitAction();

    public SpawnBaitAction onSpawnBait;

    public Transform sharkBait;

    public Vector3 spawnOffset;

    Vector3 spawnPosition;

    private void Awake()
    {
        //SpawnBaitObject();
    }

    private void Update()
    {
        spawnPosition = new Vector3(transform.position.x + spawnOffset.x, transform.position.y + spawnOffset.y, transform.position.z + spawnOffset.z);
    }

    private void OnEnable()
    {
        onSpawnBait += SpawnBaitObject;
    }

    private void OnDisable()
    {
        onSpawnBait -= SpawnBaitObject;
    }

    public void SpawnBaitObject()
    {
        Instantiate(sharkBait, spawnPosition, Quaternion.identity);
    }

}
