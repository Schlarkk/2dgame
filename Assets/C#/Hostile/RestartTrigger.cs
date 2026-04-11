using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;


public class RestartTrigger : MonoBehaviour
{
    public GameObject sceneLoaderObject; // Assign the GameObject with the SceneLoader script in the Inspector

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && sceneLoaderObject != null)
        {
            SceneLoader sceneLoader = sceneLoaderObject.GetComponent<SceneLoader>();
            if (sceneLoader != null)
            {
                sceneLoader.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
