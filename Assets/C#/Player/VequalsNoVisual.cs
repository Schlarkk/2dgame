using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VequalsNoVisual : MonoBehaviour
{
    public GameObject playerNormal;
    public GameObject playerSpecial;
    void Update()
    {
        if(Input.GetButtonDown("Noclip"))
        {
            playerNormal.SetActive(false);
            playerSpecial.SetActive(false);
        }
    }
}
