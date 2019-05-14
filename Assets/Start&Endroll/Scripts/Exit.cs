using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace)) OnClick();
    }
    /// ボタンをクリックした時の処理
    public void OnClick()
    {
        this.GetComponent<AudioSource>().Play();
        Application.Quit();
    }
}
