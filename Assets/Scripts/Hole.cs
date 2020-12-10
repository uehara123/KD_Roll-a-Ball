using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hole : MonoBehaviour
{
    bool isHolding;

    public bool IsHolding()
    {
        return isHolding;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isHolding = true;

            // int sceneIndex = SceneManager.GetActiveScene().buildIndex;

            // SceneManager.LoadScene(sceneIndex);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isHolding = false;
        }
    }
}
