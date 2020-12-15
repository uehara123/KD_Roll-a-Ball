using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallArea : MonoBehaviour
{
    bool fallPlayer;

    public bool FallPlayer()
    {
        return fallPlayer;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            fallPlayer = true;
        }
    }
}
