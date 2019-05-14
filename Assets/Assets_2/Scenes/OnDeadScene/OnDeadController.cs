using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnDeadController : MonoBehaviour
{
    public Animator TextButtonAnim;
    public AudioSource Yes;
    public AudioSource No;
    float time = 0; 

    private void Update()
    {
        time += Time.deltaTime;
        if (time < 1f) return;
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) YesButtonClick();
        if (Input.GetKeyDown(KeyCode.Backspace)) NoButtonClick();
    }

    public void StartButtonMove()
    {
        TextButtonAnim.SetBool("SetButton", true);
    }

    public void YesButtonClick()
    {
        Yes.Play();
        Player.HP = Player.MaxHP + 50;
        GenerateEnemy.remainNum = 25;
        GenerateEnemy.destroyedEnemyNum = 0;
        GenerateEnemy.NowEnemyNum = 0;
        GenerateEnemy.launcherNum = 0;
        Launch.hasLauncher = false;
        Launch.isLaunched = false;
        StartCoroutine(wait("SampleScene"));
    }

    public void NoButtonClick()
    {
        No.Play();
        StartCoroutine(wait("TitleScene"));
    }

    IEnumerator wait(string sceneName)
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(sceneName);
    }
}
