using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockWeapon : MonoBehaviour
{
    public GameObject WeaponColectable;
    public GameObject WeaponEnabler;

    void Update()
    {
        if(!WeaponColectable.activeSelf)
        {
            WeaponEnabler.SetActive(true);
        }
        else
        {
            WeaponEnabler.SetActive(false);
        }
    }
}
