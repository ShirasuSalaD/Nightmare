using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EscapeDream : MonoBehaviour {

    GameObject fadePanel;
    bool isStarted;
	// Use this for initialization
	void Start () {
        fadePanel = GameObject.Find("FadePanel");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void StartEscapeDream(){
        if (!isStarted)
        {
            fadePanel.GetComponent<Image>().DOFade(1f, 3f);
            isStarted = true;
        }
    }
}
