using UnityEngine;

public class GameClearDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("ごーるしました!");
        }
    }
}
