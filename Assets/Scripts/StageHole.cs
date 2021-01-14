using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageHole : MonoBehaviour
{
    public GameOverDetector gameOverDetector;
    public Hole hole;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            hole.destroyedPlayer = true;
            Destroy(other);
            gameOverDetector.GameOver();
        }
    }
}
