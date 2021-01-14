using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerObject : MonoBehaviour
{
    public GameOverDetector gameOverDetector;
    public Hole hole;
    public GameObject Player;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hole.destroyedPlayer = true;
            StartCoroutine(PlayerOff());
            gameOverDetector.GameOver();
        }
    }

    IEnumerator PlayerOff()
    {
        int counter = 1;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1.0f);
            counter--;
        }
        Player.SetActive(false);
    }
}
