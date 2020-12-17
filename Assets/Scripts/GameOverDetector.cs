using UnityEngine;

public class GameOverDetector : MonoBehaviour
{
    public Hole hole;
    public GameController gameController;

    public void GameOver()
    {
        if (hole.IsHolding())
        {
            gameController.SelectGameOverDescription();
        }
    }
}
