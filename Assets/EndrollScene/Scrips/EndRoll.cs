using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndRoll : MonoBehaviour
{

    GameObject parent;

    private int pause = 1;

    public bool isStart = false;

    public GameObject pushEnter;

    // Start is called before the first frame update
    void Start()
    {
        parent = GameObject.Find("Parent");
    }

    // Update is called once per frame
    void Update()
    {
        if(isStart){
            if (parent.transform.localPosition.y >= 2000)
            {
                pushEnter.GetComponent<Text>().color = new Color(1f, 1f, 1f, 1f);
                pushEnter.GetComponent<Text>().text = "「Enter」でタイトルへ / 「Esc」でゲーム終了";
                pushEnter.SetActive(true);
                pause = 0;
                if(Input.GetKeyDown(KeyCode.Return)){
                    SceneManager.LoadScene("TitleScene");
                }
            }
            parent.transform.Translate(0, 0.3f * pause, 0);

        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
    }
}
