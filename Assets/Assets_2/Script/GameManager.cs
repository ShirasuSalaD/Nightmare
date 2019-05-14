using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour {

    public GameObject mainCamera;
    public GameObject subCamera;
    bool foucsMode = false;
    public GameObject Door;
    public Animator playerAnimator;
    public GameObject player;
    public GameObject CenterImage;
    public Canvas canvas;


	// Use this for initialization
	void Start () {
        CenterImage = GameObject.Find("Center");
        subCamera = GameObject.FindWithTag("SubCamera");
        mainCamera = GameObject.FindWithTag("MainCamera");
        player = GameObject.FindWithTag("Player");
        playerAnimator = player.GetComponent<Animator>();
        CenterImage = GameObject.Find("Center");
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        CenterImage.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
        gameObject.GetComponent<GenerateEnemy>().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
        if(!foucsMode){
            subCamera.transform.position = mainCamera.transform.position;
            subCamera.transform.rotation = mainCamera.transform.rotation;
        }
        if (Input.GetKeyDown(KeyCode.O) || Input.GetButtonUp("Fire1")){
            if(foucsMode){
                //CenterImage.SetActive(false);
                if (Launch.isLaunched)
                {
                    playerAnimator.SetBool("isLauncherSetUp", false);
                    Launch.hasLauncher = false;
                }
                else
                {
                    playerAnimator.SetBool("isSetUp", true);
                }
                CenterImage.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
                canvas.worldCamera = mainCamera.GetComponent<Camera>();
                playerAnimator.SetFloat("Speed", 1f);
                playerAnimator.SetBool("isSetUp", false);
                mainCamera.SetActive(true);
                subCamera.SetActive(false);
                foucsMode = false;
            }else{
                playerAnimator.SetFloat("Speed", 0.35f);
                if(Launch.hasLauncher){
                    playerAnimator.SetBool("isLauncherSetUp", true);
                }else{
                    playerAnimator.SetBool("isSetUp", true);
                }
                CenterImage.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.8f);
                canvas.worldCamera = subCamera.GetComponent<Camera>();
                subCamera.transform.DOLocalMove(new Vector3(0.45f, 1.4f, -0.8f), 0.3f);
                mainCamera.SetActive(false);
                subCamera.SetActive(true);
                foucsMode = true;
            }
        }
	}
}
