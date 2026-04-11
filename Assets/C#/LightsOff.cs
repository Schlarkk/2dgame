using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsOff : MonoBehaviour
{
    public GameObject Lights;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Lights.SetActive(false);
        }
    }
}
