using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;

public class BaitInWater : MonoBehaviour
{
    //public BehaviorTree sharkBehaviour;

    public List<GameObject> sharkList;

    public SharedTransformList baitList;

    //[SerializeField] private AudioClip[] baitSplashAudio;

    private void Start()
    {
        sharkList = new List<GameObject>();
        
    }

    public void Update()
    {
        if (sharkList.Count != GameObject.FindGameObjectsWithTag("Shark").Length)
        {
            UpdateSharkList();
        }
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SharkBait"))
        {
            
            if (sharkList != null)
            {
                foreach (GameObject shark in sharkList)
                {
                    if (!baitList.Value.Contains(other.transform))
                        baitList.Value.Add(other.transform);
                    //shark.GetComponent<BehaviorTree>().GetVariable("BaitPos").SetValue(other.transform);
                    shark.GetComponent<BehaviorTree>().GetVariable("isBaitInWater").SetValue(true);
                }
            }

        }
    }

    public void UpdateSharkList()
    {
        foreach (GameObject shark in GameObject.FindGameObjectsWithTag("Shark"))
        {
            if (!sharkList.Contains(shark))
            {
                sharkList.Add(shark);
            }
        }

        for (int i = 0; i < sharkList.Count; i++)
        {
            if (sharkList[i] == null)
            {
                sharkList.Remove(sharkList[i]);
            }
        }

        if (sharkList.Count >= 1)
        {
            baitList = (SharedTransformList)sharkList[0].GetComponent<BehaviorTree>().GetVariable("BaitList");
        }
    }
}
