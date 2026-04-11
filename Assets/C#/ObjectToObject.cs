using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToObject : MonoBehaviour
{
    public Transform target;
    public GameObject user;

    void Update()
    {
        if (target != null && user != null)
        {
            user.transform.position = target.position;
        }
    }
}
