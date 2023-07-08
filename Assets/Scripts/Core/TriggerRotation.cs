using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRotation : MonoBehaviour
{
    public float rotateSpeed = 2f;    

    void Start()
    {
        StartCoroutine(RotationUpdate());
    }

    private IEnumerator RotationUpdate()
    {
        while(true)
        {
            yield return null;

            transform.Rotate(0, 0, rotateSpeed);
        }
    }
}
