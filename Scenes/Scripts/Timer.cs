// 画面上のタイマーを表示する

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    int target_time;
    float time;
    int time_int;
    bool watch_flag;
    bool afterGame_flag;
    Text timer_display;
    Text score;
    Text gamescore;
    GameObject menu;

    void Start()
    {
        menu = GameObject.Find("Player/OVRCameraRig/TrackingSpace/CenterEyeAnchor/Canvas/menu");
        score = GameObject.Find("Player/OVRCameraRig/TrackingSpace/CenterEyeAnchor/Canvas/menu/Score/value").GetComponent<Text>();
        afterGame_flag = false;
        timer_display = GameObject.Find("Player/OVRCameraRig/TrackingSpace/CenterEyeAnchor/Canvas/Timer/Time").GetComponent<Text>();
        watch_flag = false;
        target_time=30;
        StartTimer();
    }

    public void StartTimer()
    {
        watch_flag = true;
        time = 0f;
    }

    public void PauseTimer()
    {
        watch_flag = false;
    }

    public bool getTimerFlag()
    {
        return watch_flag;
    }

    

    // Update is called once per frame
    void Update()
    {
        if (watch_flag)
        {
            time += Time.deltaTime;
            if (time>=target_time)
            {
                watch_flag = false;
                timer_display.text = "0";
                // do after end
                afterGame_flag = true;
            }
            else
            {
                time_int = (int)(target_time - time);
                timer_display.text = time_int.ToString();
            }

        }
        if(afterGame_flag)
        {
            afterGame_flag=false;
            gamescore = GameObject.Find("Player/OVRCameraRig/TrackingSpace/CenterEyeAnchor/Canvas/Stock/Number").GetComponent<Text>();
            score.text = gamescore.text;
            menu.SetActive(true);
        }

    }
}
