using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehavior : MonoBehaviour
{
    public GameObject Weapon;

    private bool isSpinEnabled = false;
    public float spinSpeed = 200.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0)) // Left mouse button pressed
        {
            StartSpinning();
            Weapon.SetActive(true);
        }

        if (Input.GetMouseButtonUp(0)) // Left mouse button released
        {
            StopSpinning();
            Weapon.SetActive(false);
        }
        
    }

    void FixedUpdate()
    {
        if (isSpinEnabled)
        {
            // Rotate the Weapon GameObject while the button is held
            Weapon.transform.Rotate(Vector3.forward * spinSpeed * Time.fixedDeltaTime);
        }
    }

    void StopSpinning()
    {
        isSpinEnabled = false;
    }

    void StartSpinning()
    {
        isSpinEnabled = true;
    }
}
