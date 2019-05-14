using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Start : MonoBehaviour
{
    public Animator fade;
    public Button exitButton;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) OnClick();
    }
    /// ボタンをクリックした時の処理
    public void OnClick()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        this.GetComponent<AudioSource>().Play();
        this.GetComponent<Button>().interactable = false;
        exitButton.interactable = false;
        fade.SetBool("fadeout", true);
        yield return new WaitForSeconds(1.4f);
        SceneManager.LoadScene("StartScene");
    }
}
