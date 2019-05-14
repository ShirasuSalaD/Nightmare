using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Result : MonoBehaviour
{
    private Text timerText;

    private Text timeStringText;

    Text HPStringText;

    Text HPText;

    Text MaxHPText;

    private Text scoreStringText;

    private Text scoreText;

    private Text rankStringText;

    private GameObject rankImage;
    public GameObject pushEnter;
    bool isEntered;

    private int score;

    Renderer _renderer;

    public AudioClip drumRoll;
    public AudioClip rollEnd;

    public AudioClip S_SE;
    public AudioClip A_SE;
    public AudioClip B_SE;

    public AudioClip MoveSE;

    public AudioClip bgm;
    private AudioClip rank_SE;
    AudioSource audioSource;

    bool isResultEnd;

    public Sprite S;
    public Sprite A;
    public Sprite B;

    int minute = 0;
    float seconds;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        seconds = Timer.resultSeconds;
        minute = Timer.resultMinute;


        timerText = GameObject.Find("TimerText").GetComponent<Text>();
        timeStringText = GameObject.Find("TimeStringText").GetComponent<Text>();

        scoreStringText = GameObject.Find("ScoreStringText").GetComponent<Text>();
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();

        HPStringText = GameObject.Find("HPStringText").GetComponent<Text>();
        HPText = GameObject.Find("HPText").GetComponent<Text>();
        
        MaxHPText = GameObject.Find("MaxHPText").GetComponent<Text>();
        MaxHPText.text = "/" + Player.MaxHP.ToString();

        rankStringText = GameObject.Find("RankStringText").GetComponent<Text>();
        rankImage = GameObject.Find("RankImage");

        pushEnter = GameObject.Find("PushEnter");
        rankImage.SetActive(false);
        pushEnter.SetActive(false);
        //rankImage.SetActive(false);
        //scoreText.text = "888888";

        //score = 10000 / (Player.MaxHP - Player.HP + 100) + 10000 / ((int)Timer.resultTime + 100);

        score = DecideScore(Player.HP, Player.MaxHP, minute, (int)seconds);

        StartCoroutine(DelayMethod(1.5f));

        //StartCoroutine(ScoreAnimation(score, 1));

    }

    private IEnumerator DelayMethod(float waitTime)
    {
        //for(int i=0; i < 888800; ++i){
        //    score += 100;
        //    scoreText.text = score.ToString();
        //    yield return new WaitForSeconds(0);
        //    action();
        //}

        yield return new WaitForSeconds(waitTime);

        timerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
        timerText.transform.DOLocalMove(new Vector3(105f,138f,0),1.0f).SetEase(Ease.InOutElastic);
        yield return new WaitForSeconds(0.3f);

        HPText.text = Player.HP.ToString();
        HPText.transform.DOLocalMove(new Vector3(40f,69f,0), 1.0f).SetEase(Ease.InOutElastic);
        yield return new WaitForSeconds(1.0f);

        //今回のスコア
        int after = score;
        //0fを経過時間にする
        float elapsedTime = 0.0f;

        audioSource.PlayOneShot(drumRoll);

        //timeが０になるまでループさせる
        while (elapsedTime < 1)
        {
            float rate = elapsedTime / 1;
            // テキストの更新
            scoreText.text = (after * rate).ToString("f0");

            elapsedTime += Time.deltaTime;
            // 0.01秒待つ
            yield return new WaitForSeconds(0.03f);
        }

        audioSource.Stop();

        audioSource.PlayOneShot(rollEnd);

        // 最終的な着地のスコア
        scoreText.text = after.ToString();

        yield return new WaitForSeconds(1.0f);

        audioSource.PlayOneShot(MoveSE);
        rankImage.SetActive(true);
        rankImage.GetComponent<RectTransform>().localScale = new Vector3(100f,100f,1f);
        rankImage.transform.DORotate(new Vector3(0f, 0f, 3600f), 1f,RotateMode.FastBeyond360).SetEase(Ease.InSine);
        rankImage.transform.DOScale(new Vector3(1f, 1f, 1f),1.0f).SetEase(Ease.OutSine).OnComplete(()=>{
            rankImage.transform.DOScale(new Vector3(1.5f,1.5f,1f),0.25f).OnComplete(()=>{
                rankImage.transform.DOScale(new Vector3(1.0f, 1.0f, 1f), 0.25f);
            });
            audioSource.PlayOneShot(rank_SE);
        });
        yield return new WaitForSeconds(3.0f);
        pushEnter.SetActive(true);
        pushEnter.GetComponent<Text>().DOFade(0.2f, 1.0f).SetLoops(-1,LoopType.Yoyo);
        //audioSource.loop = true;
        audioSource.PlayOneShot(bgm);
        isResultEnd = true;

    }

    // Update is called once per frame
    void Update()
    {
        if(isResultEnd && !isEntered && Input.GetKeyDown(KeyCode.Return)){
            EndRoll endRoll = GameObject.Find("EndrollManager").GetComponent<EndRoll>();
            endRoll.pushEnter = GameObject.Find("PushEnter");
            endRoll.isStart = true;
            isEntered = true;
            pushEnter.SetActive(false);
        }
        if(!audioSource.isPlaying && isResultEnd){
            audioSource.PlayOneShot(bgm);
        }
        //resultTimeText.text = timerText.text;
    }

    int DecideScore(int hp, int maxhp, int _minute, int _seconds)
    {
        int _score = 0;
        int second = _minute * 60 + _seconds;
        if (second <= 600)
        {
            _score = 8000 / (maxhp - hp + 10) + (600 - second) * 10;
        } else
        {
            _score = 8000 / (maxhp - hp + 10);
        }

        if (_score >= 6000)
        {
            rankImage.GetComponent<Image>().sprite = S;
            rank_SE = S_SE;
        } else if (_score < 6000 && _score >= 5000)
        {
            rankImage.GetComponent<Image>().sprite = A;
            rank_SE = A_SE;
        } else
        {
            rankImage.GetComponent<Image>().sprite = B;
            rank_SE = B_SE;
        }
        return _score;
    }
}
