using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    public Hole hole;

    private void Start()
    {
        offset = GetComponent<Transform>().position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().position = target.position + offset;

        if (hole.DestroyedPlayer())
        {
            enabled = false;
        }
    }
}
