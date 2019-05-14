using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class next : MonoBehaviour
{
    public Animator fade;
    public GameObject player;
    public GameObject playerForAnim;
    public GameObject mainCamera;
    public GameObject CameraForAnim;
    public Text text;
    public AudioSource ZombieVoice;

    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine("nextAnimation");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator nextAnimation()
    {
        fade.SetBool("fadeout", true);
        yield return new WaitForSeconds(2f);

        playerForAnim.SetActive(false);
        player.SetActive(true);
        mainCamera.SetActive(true);
        CameraForAnim.SetActive(false);
        fade.SetBool("fadeout", false);
        yield return new WaitForSeconds(1f);

        ZombieVoice.Play();
        yield return new WaitForSeconds(4f);

        text.text = "ドアの方から音がする…";
        yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.P) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)));

        text.text = "";
        GameController.canMove = true;
    }
}
