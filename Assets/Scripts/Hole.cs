using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hole : MonoBehaviour
{
    bool isHolding, destroyedPlayer = false;
    int counter;


    public bool IsHolding()
    {
        return isHolding;
    }
    public bool DestroyedPlayer()
    {
        return destroyedPlayer;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isHolding = true;
            destroyedPlayer = true;

            Destroy(other);
            StartCoroutine(ResetPosition());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isHolding = true;
        }
    }

    IEnumerator ResetPosition()
    {
        counter = 1;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1.0f);
            counter--;
        }
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }
}
