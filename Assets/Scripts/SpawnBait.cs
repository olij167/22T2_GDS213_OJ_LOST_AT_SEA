using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBait : MonoBehaviour
{
    public delegate void SpawnBaitAction();

    public SpawnBaitAction onSpawnBait;

    public GameObject sharkBait, hand;

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
        Instantiate(sharkBait, hand.transform.position, Quaternion.identity);
    }

}
