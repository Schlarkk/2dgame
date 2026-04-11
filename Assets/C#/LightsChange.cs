using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsChange : MonoBehaviour
{
    public GameObject normalLight;
    public GameObject redLight;

    void Update()
    {
        if(!normalLight.activeSelf)
        {
            redLight.SetActive(true);
        }
        else
        {
            redLight.SetActive(false);
        }
    }
}
