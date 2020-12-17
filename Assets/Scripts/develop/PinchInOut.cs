/* 参考元URL : https://www.hekeke999.xyz/entry/2019/05/24/160048 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchInOut : MonoBehaviour
{
    float heightMin = 4.0f;
    float heightMax = 20.0f;
    bool Min, Max, kakudai, shukushou;

    // 前回の2点間の距離
    float pre_point2Dist;
    // 初期値
    float cameraHeight;
    float heightLimitJudg;
    Vector3 pre_t1;
    Vector3 pre_t2;

    float var;

    public Transform target;
    private Vector3 offset;
    public Hole hole;

    private void Start()
    {
        cameraHeight = this.transform.position.y;
        offset = GetComponent<Transform>().position - target.position;
    }

    private void Update()
    {
        /*--- ピンチイン・ピンチアウト処理 ---*/
        // マルチタッチ判定
        if (Input.touchCount >= 2)
        {
            // タッチしている2点を取得
            Touch t1 = Input.GetTouch(0);
            Touch t2 = Input.GetTouch(1);

            // 2点タッチ開始時の距離を保持
            if (t2.phase == TouchPhase.Began)
            {
                pre_point2Dist = Vector2.Distance(t1.position, t2.position);
            }
            // タッチ位置の変化を検出
            else if (t1.phase == TouchPhase.Moved || t2.phase == TouchPhase.Moved)
            {
                // 2点タッチの位置、各タッチ位置の前回値との差を取得
                float point2Dist = Vector2.Distance(t1.position, t2.position);
                float dist1 = Vector2.Distance(t1.position, pre_t1);
                float dist2 = Vector2.Distance(t2.position, pre_t2);
                // 2点間の差が縮んだらマイナス,開いたらプラスにする
                if (Mathf.Sign(point2Dist - pre_point2Dist) >= 0)
                {
                    cameraHeight = (dist1 + dist2) / 100.0f;
                    shukushou = false;
                    kakudai = true;
                }
                else if (Mathf.Sign(point2Dist - pre_point2Dist) <= 0)
                {
                    cameraHeight = -(dist1 + dist2) / 100.0f;
                    shukushou = true;
                    kakudai = false;

                }

                // タッチ位置の差に変化があれば変更
                if (cameraHeight != 0)
                {
                    float y = this.transform.position.y;
                    float heightLimitJudg = cameraHeight + y;
                    // 限界地をオーバーした際の処理
                    if (heightLimitJudg > (heightMax + 1.0f))
                    {
                        // Min = false;
                        // Max = true;
                        heightLimitJudg = heightMax;
                        // var = heightLimitJudg;
                        // offset.z -= 6.0f; どっか飛んで行った

                        // this.transform.position = new Vector3(0, heightLimitJudg, -7.5f);
                        // this.transform.position = new Vector3(target.position.x + offset.x, heightLimitJudg, target.position.z + offset.z);
                    }
                    else if (heightLimitJudg < (heightMin - 1.0f))
                    {
                         // Min = true;
                        // Max = false;
                        heightLimitJudg = heightMin;
                        //var = heightLimitJudg;
                        // offset.z += 2.5f;　どっか飛んで行った
                        // this.transform.position = new Vector3(0, heightLimitJudg, -1.5f);
                    }
                    else
                    {
                        /* Min = false;
                        Max = false;
                        if (kakudai)
                        {
                            var += cameraHeight;
                        }
                        if (shukushou)
                        {
                            var -= cameraHeight;
                        } */
                        this.transform.Translate(0, 0, cameraHeight);
                        // this.transform.Translate(target.position.x + offset.x, target.position.y + offset.y, cameraHeight);
                    }
                }
                // 前回値として2点間距離を保持
                pre_point2Dist = point2Dist;
            }
            // 前回値としてタッチ位置を保持
            pre_t1 = t1.position;
            pre_t2 = t2.position;
        }
    }

    /* void LateUpdate()
    {
        if (Max)
        {
            GetComponent<Transform>().position = new Vector3(target.position.x + offset.x, target.position.y + offset.y + heightMax, target.position.z + offset.z - 6.0f);
        }
        else if (Min)
        {
            GetComponent<Transform>().position = new Vector3(target.position.x + offset.x, target.position.y + offset.y + heightMin, target.position.z + offset.z + 2.5f);
        }
        else
        {
            GetComponent<Transform>().position = new Vector3(target.position.x + offset.x, target.position.y + offset.y + var, target.position.z + offset.z);
        }
            // GetComponent<Transform>().position = new Vector3(target.position.x + offset.x, target.position.y + offset.y + var, target.position.z + offset.z);

        if (hole.DestroyedPlayer())
        {
            enabled = false;
        }
    } */
}
