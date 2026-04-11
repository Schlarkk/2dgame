using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpin : MonoBehaviour
{
    public Animator wall;

    void OnTriggerEnter2D(Collider2D other)
    {
        wall.SetTrigger("Random");
    }
}
