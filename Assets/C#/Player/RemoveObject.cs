using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveObject : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D other)
    { 
        if (other.CompareTag("Hostile"))
        {
            // Disable the GameObject with the "Hostile" tag
            other.gameObject.SetActive(false);
        }
    }
}
