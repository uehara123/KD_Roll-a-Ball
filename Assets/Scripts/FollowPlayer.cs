using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().position = target.position;
    }
}
