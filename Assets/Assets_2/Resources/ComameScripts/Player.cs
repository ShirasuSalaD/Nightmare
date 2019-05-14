using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    public float invincibilityTime = 1.0f; // 無敵時間
    public int specialAttackRatio = 20;
    public int normalDamage = 5;
    public int specialDamage = 20;
    public Animator fade;

    public static int HP = 100;
    public static int MaxHP;
    private GameObject HPBar;
    private PlayerAudio playerAudio;


    void Start() {
        MaxHP = HP;
        HPBar = GameObject.Find("HPBar");


        gameObject.AddComponent<AudioSource>();
        gameObject.AddComponent<PlayerAudio>();
        playerAudio = GetComponent<PlayerAudio>();

        gameObject.tag = "Player";
        Debug.Log(HP);
    }
    
    private void DecreaseHP(int value) {
        if (HP > value)
        {
            HP = HP - value;
            Debug.Log(HP);
        } else
        {
            HP = 0;
        }

        HPBar.GetComponent<Image>().fillAmount = (float)HP / MaxHP;
    }

    private void Heal(int value) {
        HP = HP + value;
        if (HP > 100) {
            HP = 100;
        }

        HPBar.GetComponent<Image>().fillAmount = (float)HP / MaxHP;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "heal")
        {
            Heal(30);
            playerAudio.soundHeal();
        }else if (other.gameObject.tag == "launcherModel"){
            Launch.hasLauncher = true;
        }else if (other.gameObject.tag == "goal")
        {
            StartCoroutine(Fade());
        }
    }
    IEnumerator Fade(){
        fade.SetBool("fadeout", true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Ending");
    }

    private float deltaTime = 0.0f;
    private void OnCollisionStay(Collision other)
    {
        // ダメージ後一定の無敵時間を設定
        if (deltaTime > invincibilityTime && other.gameObject.tag == "enemy")
        {
            deltaTime = 0.0f;
            switch (selectAttackType()) {
                case "normal":
                    DecreaseHP(normalDamage);
                    playerAudio.soundNormalDamage();
                    break;
                case "special":
                    DecreaseHP(specialDamage);
                    playerAudio.soundSpecialDamage();
                    break;
            }
        } else
        {
            deltaTime += Time.deltaTime;
        }

        if (HP == 0) {
            onDead();
            //Destroy(gameObject);
        }
    }

    private string selectAttackType() {
        float random = Random.Range(0f, 1f);
        float ratio = (float)specialAttackRatio / 100;

        if (random <= ratio) {
            return "special";
        } else {
            return "normal";
        }

    }

    private void onDead() {
        SceneManager.LoadScene("OnDeadScene");
    }
}
