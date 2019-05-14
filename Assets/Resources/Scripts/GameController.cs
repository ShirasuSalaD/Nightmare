using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject gameStartCanvas;
    public Animator animaionCamera1;
    public Animator fade;
    public Animator door;
    public GameObject mainCamera;
    public GameObject sleepPoint;
    public GameObject player;
    public GameObject playerForAnim;
    public static bool canMove;
    bool isStart;
    bool isSet;
    bool madePlayer;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        isStart = false;
        isSet = false;
        madePlayer = false;
        door.SetBool("open", true);
        StartCoroutine(DoorClose(2f));
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSet && mainCamera.activeSelf) {
            sleepPoint.SetActive(true);
            Destroy(playerForAnim);
            player.SetActive(true);
            isSet = false;
        }

        if (gameStartCanvas.activeSelf)
        {
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) && !isStart) StartMovie();
            if (Input.GetKeyDown(KeyCode.Backspace)) NotStart();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //if (isStart) return;
        if ((Input.GetKeyDown(KeyCode.P) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) 
            && !gameStartCanvas.activeSelf && mainCamera.activeSelf && !isStart)
        {
            canMove = false;
            StartCoroutine(SetCanvas());
        }
    }

    public void StartMovie()
    {
        

        if (gameStartCanvas.transform.GetChild(0).GetComponent<Text>().text == "本当の本当に寝ますか？")
        {
            isStart = true;
            fade.SetBool("fadeout", true);
            gameStartCanvas.SetActive(false);
            StartCoroutine(wait(2f));
        } else if (gameStartCanvas.transform.GetChild(0).GetComponent<Text>().text == "本当に寝ますか？")
        {
            gameStartCanvas.SetActive(false);
            StartCoroutine(SetCanvas(0.8f));
            gameStartCanvas.transform.GetChild(0).GetComponent<Text>().text = "本当の本当に寝ますか？";
        } else
        {
            gameStartCanvas.SetActive(false);
            StartCoroutine(SetCanvas(0.3f));
            gameStartCanvas.transform.GetChild(0).GetComponent<Text>().text = "本当に寝ますか？";
        }
    }

    public void NotStart()
    {
        gameStartCanvas.SetActive(false);
        canMove = true;
        gameStartCanvas.transform.GetChild(0).GetComponent<Text>().text = "やっぱり寝ますか？";
    }

    IEnumerator wait(float second)
    {
        yield return new WaitForSeconds(second);
        SceneManager.LoadScene("StartMovie");
    }

    IEnumerator SetCanvas(float second)
    {
        yield return new WaitForSeconds(second);
        gameStartCanvas.SetActive(true);
    }

    IEnumerator DoorClose(float second)
    {
        yield return new WaitForSeconds(second);
        door.SetBool("open", false);
        animaionCamera1.SetBool("Start", true);
    }

    IEnumerator SetCanvas()
    {
        yield return null;
        gameStartCanvas.SetActive(true);
    }
}
