// Unity 3D/2Dゲーム開発実践入門 Unity 2019対応版 から引用

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 重力加速度
    const float Gravity = 9.81f;

    // 重力適応具合
    public float gravityScale = 1.0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 vector = new Vector3();

        // キーの入力を検知しベクトルを設定
        vector.x = Input.GetAxis("Horizontal");
        vector.z = Input.GetAxis("Vertical");

        // シーンの重力を入力ベクトルの方向に合わせて変化させる
        Physics.gravity = Gravity * vector.normalized * gravityScale;
    }
}
