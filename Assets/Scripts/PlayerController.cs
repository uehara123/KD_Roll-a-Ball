// Unity 3D/2Dゲーム開発実践入門 Unity 2019対応版 から引用

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float x;
    float z;
    float speed = 10.0f;
    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Application.isMobilePlatform)
        {
            // ターゲット端末の縦横の表示に合わせてremapする
            x = Input.acceleration.x;
            z = Input.acceleration.y;
        }
        else
        {
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");
        }
    }
    void FixedUpdate()
    {
        // clamp acceleration vector to the unit sphere

        // Move object
        rb.AddForce(new Vector3(x, 0, z) * speed);
    }
}
