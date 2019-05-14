using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Timeline;

public class TextManager : MonoBehaviour {
    
    Text Text;
    string beforeText;
    public string[] sentense = new string[5];
    public int j = 0;
    bool isTexting = false;
    float deltaTime = 0f;


	// Use this for initialization
	void Start () {
        Text = GetComponent<Text>();
        //InvokeRepeating("StartTalk", 1f, 1f);
        StartTalk(sentense[j]);
	}

    void StartTalk(string text){
        StartCoroutine(Talk(text));
        j++;
    }
	
    IEnumerator Talk(string text){
        for (int i = 1; i <= text.Length; i++)
        {
            Text.text = text.Substring(0, i);
            yield return new WaitForSeconds(0.1f);
        }
    }

	// Update is called once per frame
	void Update () {
        deltaTime += Time.deltaTime;
        if (deltaTime >= 4f && j<5) {
            StartTalk(sentense[j]);
            deltaTime = 0f;
        }
	}
}
