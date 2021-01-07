using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClearDetector : MonoBehaviour
{
    public GameController gameController;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Time.timeScale = 0f;
            gameController.SelectGameClearDescription();

        }
    }
}
