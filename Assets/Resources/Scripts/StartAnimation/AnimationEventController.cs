using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationEventController : MonoBehaviour
{
    public Animator fade;

    void StartGame()
    {
        fade.SetBool("fadeout", true);
        StartCoroutine(wait(2f));
    }

    IEnumerator wait(float second)
    {
        yield return new WaitForSeconds(second);
        //ゲーム本編に移行
        Player.HP = 100;
        GenerateEnemy.remainNum = 25;
        GenerateEnemy.destroyedEnemyNum = 0;
        GenerateEnemy.NowEnemyNum = 0;
        GenerateEnemy.launcherNum = 0;
        Launch.hasLauncher = false;
        Launch.isLaunched = false;
        SceneManager.LoadScene("SetumeiScene");
    }
}
