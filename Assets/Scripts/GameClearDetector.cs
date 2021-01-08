using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameClearDetector : MonoBehaviour
{
    public GameController gameController;
    public TimeController timeController;

    bool gameClearFlag;

    public bool GameClear()
    {
        return gameClearFlag;
    }

    private void Start()
    {
        gameClearFlag = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            gameClearFlag = true;
            Time.timeScale = 0f;
            gameController.SelectGameClearDescription();
            timeController.TimeShow();
        }
    }
}
