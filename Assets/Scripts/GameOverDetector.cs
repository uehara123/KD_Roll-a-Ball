using UnityEngine;

public class GameOverDetector : MonoBehaviour
{
    public Hole hole;
    void OnGUI()
    {
        if (hole.IsHolding())
        {
            GUI.Label(new Rect(50, 50, 100, 30), "Game Over!");
        }
    }
}
