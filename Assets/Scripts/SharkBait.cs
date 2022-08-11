using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkBait : MonoBehaviour
{
    public float destroyTimer = 3f;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Shark"))
        {
            Invoke("DestroyBait", destroyTimer);
        }
    }

    void DestroyBait()
    {
        Destroy(gameObject);
    }
}
