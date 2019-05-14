using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GenerateEnemy : MonoBehaviour {

    GameObject player;
    float deltaTime;
    Vector3 enemyPos;
    Vector3 launcherPos;
    public static int launcherNum;
    public static Text ZombieNumText;
    public static int remainNum = 25;


    public static int destroyedEnemyNum = 0;
    public static int NowEnemyNum = 0;
    public GameObject timeline2;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        ZombieNumText = GameObject.Find("ZombieNum").GetComponent<Text>();
        ZombieNumText.text = remainNum.ToString();
        timeline2 = GameObject.Find("TimeLineParent").transform.GetChild(0).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        deltaTime += Time.deltaTime;
        if(deltaTime >= 10f && launcherNum < 1){
            launcherPos = player.transform.position + new Vector3(Random.Range(10f,20f),0f,Random.Range(10f,20f));
            GameObject launcher = (GameObject)Resources.Load("Prefabs/launcherModel");
            launcher = Instantiate(launcher, launcherPos, Quaternion.identity);
            
            launcherNum++;
            deltaTime = 0f;
        }
        if(NowEnemyNum < 5 && remainNum > 4){
            Generate();
        }
        if(remainNum == 0){
            timeline2.SetActive(true);
            Timer.isEnd = true;
        }
        Debug.Log(remainNum);
	}

    void Generate(){
        enemyPos = player.transform.position + new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(10f, 20f));
        GameObject enemy = (GameObject)Resources.Load("Prefabs/Zombie");
        enemy = Instantiate(enemy, enemyPos, Quaternion.identity);
        NowEnemyNum++;
        //deltaTime = 0f;
    }
    public static void DecreaseNum(){
        remainNum--;
        ZombieNumText.text = remainNum.ToString();
    }

    public static void DestroyEnemy(){
        destroyedEnemyNum++;
        NowEnemyNum--;
        DecreaseNum();
        Debug.Log(destroyedEnemyNum);
    }
}
