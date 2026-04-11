using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEffect : MonoBehaviour
{  
    public GameObject mob;
    public GameObject bloodEffect;

    void Update()
    {
        if(!mob.activeSelf)
        {
            bloodEffect.SetActive(true);
        }
        else
        {
            bloodEffect.SetActive(false);
        }
    }
}
