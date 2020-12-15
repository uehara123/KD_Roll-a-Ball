using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hole : MonoBehaviour
{
    bool isHolding, destroyedPlayer;
    int counter;
    public FallArea fallArea;

    public bool IsHolding()
    {
        return isHolding;
    }
    public bool DestroyedPlayer()
    {
        return destroyedPlayer;
    }

    private void OnTriggerStay(Collider other)
    {
        if (fallArea.FallPlayer())
        {
            if (other.gameObject.CompareTag("Player"))
            {
                isHolding = true;
                destroyedPlayer = true;

                Destroy(other);
                StartCoroutine(ReturnToTitle());
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isHolding = false;
        }
    }

    IEnumerator ReturnToTitle()
    {
        counter = 1;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1.0f);
            counter--;
        }
        SceneManager.LoadScene("Title");
    }
}
