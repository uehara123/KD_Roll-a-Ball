// Unity 3D/2Dゲーム開発実践入門 Unity 2019対応版 から引用

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /* float x;
    float z;*/
    float speed = 10.0f;
    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 vector = Vector3.zero;

        if (Application.isMobilePlatform)
        {
            // ターゲット端末の縦横の表示に合わせてremapする
            vector.x = Input.acceleration.x;
            vector.z = Input.acceleration.y;
        }
        else
        {
            vector.x = Input.GetAxis("Horizontal");
            vector.z = Input.GetAxis("Vertical");
        }
        rb.AddForce(vector * speed );
    }
}
