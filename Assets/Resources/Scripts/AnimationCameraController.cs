using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationCameraController : MonoBehaviour
{
    public GameObject ChangetoCamera;
    public Text text;
    AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void CameraChange1()
    {
        StartCoroutine(wait(0));
    }

    IEnumerator wait(float second)
    {
        yield return new WaitForSeconds(second);
        ChangetoCamera.SetActive(true);
        Destroy(this.gameObject);
    }

    void TextReset()
    {
        text.text = "";
    }

    void Text1()
    {
        audio.Play();
        text.text = "お疲れ様っ！";
    }

    void Text2()
    {
        text.text = "２時だよ〜…わたしもう寝るね〜…おやふみ…";
        audio.Play();
    }
}
