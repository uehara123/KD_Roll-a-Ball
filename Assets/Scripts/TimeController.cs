using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    
    public float time;

    public Text TimeText;
    public Text GoalTimeText;

    public GameClearDetector gameClearDetector;

    public bool timerflag;

    // PlayerPrefs関連
    public Text fastestTimeText;
    private float fastestTime;
    private string key = "FASTEST TIME";

    // Start is called before the first frame update
    void Start()
    {
        timerflag = true;
        time = 0f;

        fastestTime = PlayerPrefs.GetFloat(key, 9999f);
        fastestTimeText.text = "ベストタイム : " + fastestTime.ToString("F1") + "秒";
    }

    // Update is called once per frame
    void Update()
    {
        if (timerflag)
        {
            time += Time.deltaTime;
            TimeText.GetComponent<Text>().text = time.ToString("F1");
            if (gameClearDetector.GameClear())
            {
                if(time < fastestTime)
                {
                    fastestTime = time;
                    PlayerPrefs.SetFloat(key, fastestTime);
                    fastestTimeText.text = "ベストタイム : " + fastestTime.ToString("F1") + "秒";
                }
            }
        }
    }

    public void TimeShow()
    {
        GoalTimeText.text = "タイム : " + time.ToString("F1") + "秒";
        fastestTimeText.text = "ベストタイム : " + fastestTime.ToString("F1") + "秒";
    }
}
