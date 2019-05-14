using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class Setumei : MonoBehaviour {
    
    AudioSource audioSource;
    public AudioClip click_SE;
    bool isPushed;
    float deltaTime = 0.0f;
    GameObject EnterTextImage;
    bool isDisplayed;

    void Start()
    {
        EnterTextImage = GameObject.Find("EnterTextImage");
        audioSource = gameObject.GetComponent<AudioSource>();
        EnterTextImage.SetActive(false);
    }
    // Use this for initialization

    IEnumerator Onclick(){
        audioSource.PlayOneShot(click_SE);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("SampleScene");
    }

    void Update()
    {
        deltaTime += Time.deltaTime;
        if(deltaTime >= 2f){
            EnterTextImage.SetActive(true);
            if (!isDisplayed){
                EnterTextImage.transform.DOScale(new Vector3(1.1f, 1.1f, 1f), 1f).SetLoops(-1,LoopType.Yoyo);
                isDisplayed = true;
            }
            if (Input.GetKeyDown(KeyCode.Return) && !isPushed)
            {
                isPushed = true;
                StartCoroutine(Onclick());
            }
        }
    }
}
