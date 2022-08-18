using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OarSelection : MonoBehaviour
{
    public Transform oarPosition;

    public Quaternion oarRotation;

    public delegate void DeselectOarAction();

    public DeselectOarAction onDeselect;

    public void Awake()
    {
        oarRotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
    }

    public void OnEnable()
    {
        onDeselect += DeselectOar;
    }
    
    public void OnDisable()
    {
        onDeselect -= DeselectOar;
    }


    public void DeselectOar()
    {
        transform.position = oarPosition.position;
        transform.rotation = oarRotation;
    }
}
