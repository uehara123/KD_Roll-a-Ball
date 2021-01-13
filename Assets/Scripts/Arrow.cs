using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    public LookatGoal lookatgoal;
    Quaternion q = Quaternion.identity;
    Vector3 vector = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        q.z = -lookatgoal.transform.rotation.y;
        transform.rotation = q;
    }
}
