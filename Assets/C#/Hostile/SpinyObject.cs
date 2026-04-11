using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinyObject : MonoBehaviour
{
    public float rotationSpeed = 30.0f;

    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
