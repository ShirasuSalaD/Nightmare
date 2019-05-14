using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private int minute;
    [SerializeField]
    private float seconds;
    //　前のUpdateの時の秒数
    private float oldSeconds;

    public static bool isEnd;
    public static float resultSeconds;
    public static int resultMinute;

    Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        minute = 0;
        seconds = 0f;
        oldSeconds = 0f;
        timerText = GameObject.Find("Timer").GetComponent<Text>();
        timerText.text = "00:00";
        isEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        resultSeconds = seconds;
        resultMinute = minute;
        if (isEnd) return;

        seconds += Time.deltaTime;
        if (seconds >= 60f)
        {
            minute++;
            seconds = seconds - 60;
        }
        //　値が変わった時だけテキストUIを更新
        if ((int)seconds != (int)oldSeconds)
        {
            timerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
        }
        oldSeconds = seconds;
    }
}
