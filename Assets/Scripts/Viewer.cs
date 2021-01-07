using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Viewer : MonoBehaviour
{

    public float maxAngle = 60.0F;      //垂直方向に回転できる上限角度
    public float minAngle = 300.0F;     //垂直方向に回転できる下限角度
    public float rotateSpeed = 30.0f;   //回転速度(角度/秒)

    public float moveSpeed = 0.05f;     //スワイプ時移動速度
    public float pinchSpeed = 0.05f;    //ピンチ時移動速度

    private GameObject camera;          //メインカメラ
    private Vector2[] beforePoint;      //1フレーム前のポイント(各指)
    private Vector2[] nowPoint;         //現フレームのポイント(各指)
    private Vector2[] diffPoint;        //両フレームポイント差分
    private Vector2 difference;         //二本指操作チェック用差分
    private float horizontalAngle;
    private float varticalAngle;
    private float horizontalPosition;
    private float varticalPosition;

    private enum State
    {                //二本指操作の状態管理用列挙型
        DEFAULT,
        SWIPE,
        PINCH
    }
    private State nowState = State.DEFAULT; //二本指操作の現在の状態

    void Start()
    {
        camera = this.transform.Find("MapCamera").gameObject;
        beforePoint = new Vector2[2];
        nowPoint = new Vector2[2];
        diffPoint = new Vector2[2];
    }

    void Update()
    {
        //1本指でタップした場合は回転
        if (Input.touchCount == 1)
        {
            //押下時のポイントを取得
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    beforePoint[0] = Input.GetTouch(0).position;
                }
            }
            //スワイプでの継続した入力があった場合、その方向へ回転させる
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                nowPoint[0] = Input.GetTouch(0).position;
                //水平方向の移動があった場合、水平方向に回転
                if (nowPoint[0].x - beforePoint[0].x != 0)
                {
                    horizontalAngle = nowPoint[0].x - beforePoint[0].x;
                    horizontalAngle *= rotateSpeed * Time.deltaTime;

                    //水平方向に回転させる(水平方向はワールド軸)
                    this.transform.Rotate(0, horizontalAngle, 0, Space.World);
                }

                //垂直方向の回転があった場合、垂直方向に回転
                if (nowPoint[0].y - beforePoint[0].y != 0)
                {
                    varticalAngle = nowPoint[0].y - beforePoint[0].y;
                    varticalAngle *= rotateSpeed * Time.deltaTime;

                    //現在の角度を丸め込み(小数点第一位)
                    float tmpAngles = Mathf.Round(this.transform.rotation.eulerAngles.x * 10);
                    tmpAngles /= 10;

                    //上方向に回転
                    if (tmpAngles <= maxAngle)
                    {
                        //指定した最大角度を超える場合は最大角度まで回転するようにする
                        if (varticalAngle + this.transform.rotation.eulerAngles.x > maxAngle)
                        {
                            varticalAngle = maxAngle - this.transform.rotation.eulerAngles.x;
                        }
                        //垂直方向に回転させる(垂直方向はローカル軸)
                        this.transform.Rotate(varticalAngle, 0, 0, Space.Self);
                        //指定角度を超えてしまった場合の処理
                    }
                    else if (tmpAngles > maxAngle && tmpAngles <= 180)
                    {
                        //下方向にしか回転できないようにする
                        if (varticalAngle < 0)
                        {
                            this.transform.Rotate(varticalAngle, 0, 0, Space.Self);
                        }
                    }

                    //下方向に回転
                    if (tmpAngles >= minAngle)
                    {
                        //指定した最大角度を超える場合は最大角度まで回転するようにする
                        if (varticalAngle + this.transform.rotation.eulerAngles.x < minAngle)
                        {
                            varticalAngle = minAngle - this.transform.rotation.eulerAngles.x;
                        }
                        this.transform.Rotate(varticalAngle, 0, 0, Space.Self);
                        //指定角度を超えてしまった場合の処理
                    }
                    else if (tmpAngles < minAngle && tmpAngles > 180)
                    {
                        //上方向にしか回転できないようにする
                        if (varticalAngle > 0)
                        {
                            this.transform.Rotate(varticalAngle, 0, 0, Space.Self);
                        }
                    }
                }

                //現フレームのポイントを格納
                beforePoint[0] = nowPoint[0];
            }
        }
        //2本指でタップした場合はカメラ移動(ピンチとスワイプ)
        if (Input.touchCount == 2)
        {
            //2本目の指が押下された際
            if (Input.GetTouch(1).phase == TouchPhase.Began)
            {
                beforePoint[0] = Input.GetTouch(0).position;
                beforePoint[1] = Input.GetTouch(1).position;
            }
            //2本目の指が移動した場合
            if (Input.GetTouch(1).phase == TouchPhase.Moved)
            {
                nowPoint[0] = Input.GetTouch(0).position;
                nowPoint[1] = Input.GetTouch(1).position;

                //各指の1フレームで移動した分のベクトルを取得
                diffPoint[0] = nowPoint[0] - beforePoint[0];
                diffPoint[1] = nowPoint[1] - beforePoint[1];

                //更にそのベクトル間のベクトルを取得(これが各指の移動ベクトルよりも小さいならば各指は同じ方向に移動していると判断し、スワイプと判別)
                difference = diffPoint[1] - diffPoint[0];

                //スワイプかピンチかを判別する
                if (nowState == State.DEFAULT)
                {
                    bool flg1 = false;
                    bool flg2 = false;

                    if (diffPoint[0].magnitude != 0)
                    {
                        if (difference.magnitude < diffPoint[0].magnitude)
                        {
                            flg1 = true;
                        }
                    }
                    if (diffPoint[1].magnitude != 0)
                    {
                        if (difference.magnitude < diffPoint[1].magnitude)
                        {
                            flg2 = true;
                        }
                    }
                    //各指が移動しており、差分が両指の移動ベクトルよりも小さい場合はスワイプと判断
                    if (flg1 == true && flg2 == true)
                    {
                        nowState = State.SWIPE;
                    }
                    else
                    {
                        nowState = State.PINCH;
                    }
                }

                //ピンチ処理
                if (nowState == State.PINCH)
                {
                    //各指間の距離を取得し、前フレームとの差分の分、カメラを前後に移動させる
                    float nowPointDistance = Vector2.Distance(nowPoint[0], nowPoint[1]);
                    float beforePointDistance = Vector2.Distance(beforePoint[0], beforePoint[1]);
                    float distance = nowPointDistance - beforePointDistance;
                    distance *= pinchSpeed * Time.deltaTime;

                    //現在の角度に応じて移動方向を算出
                    Vector3 direction = Quaternion.Euler(0, camera.transform.localEulerAngles.y, 0) * new Vector3(0, 0, distance);
                    direction = transform.TransformDirection(direction);
                    camera.transform.position = new Vector3(camera.transform.position.x + direction.x, camera.transform.position.y + direction.y, camera.transform.position.z + direction.z);

                }
                //カメラ移動処理
                else if (nowState == State.SWIPE)
                {
                    //水平方向の移動
                    if (nowPoint[0].x - beforePoint[0].x != 0)
                    {
                        //水平方向の移動差分を取得
                        horizontalPosition = nowPoint[0].x - beforePoint[0].x;
                        horizontalPosition *= moveSpeed * Time.deltaTime;
                        //現在の角度に応じて移動方向を算出
                        Vector3 direction = Quaternion.Euler(0, camera.transform.localEulerAngles.y, 0) * new Vector3(horizontalPosition, 0, 0) * (-1);
                        direction = transform.TransformDirection(direction);
                        camera.transform.position = new Vector3(camera.transform.position.x + direction.x, camera.transform.position.y + direction.y, camera.transform.position.z + direction.z);
                    }
                    //垂直方向の移動
                    if (nowPoint[0].y - beforePoint[0].y != 0)
                    {
                        //垂直方向の移動差分を取得
                        varticalPosition = (nowPoint[0].y - beforePoint[0].y) * (-1);
                        varticalPosition *= moveSpeed * Time.deltaTime;
                        //現在の角度に応じて移動方向を算出
                        Vector3 direction = Quaternion.Euler(0, camera.transform.localEulerAngles.y, 0) * new Vector3(0, varticalPosition, 0);
                        direction = transform.TransformDirection(direction);
                        camera.transform.position = new Vector3(camera.transform.position.x + direction.x, camera.transform.position.y + direction.y, camera.transform.position.z + direction.z);
                    }
                }

                //現フレームのポイントを格納
                beforePoint[0] = nowPoint[0];
                beforePoint[1] = nowPoint[1];
            }
            //2本目の指が離れた場合(指1本になった場合)
            if (Input.GetTouch(1).phase == TouchPhase.Ended)
            {
                //今のポイントを格納して初期化(やらないと回転が飛ぶ)
                beforePoint[0] = Input.GetTouch(0).position;
                nowState = State.DEFAULT;
            }
        }
    }
}