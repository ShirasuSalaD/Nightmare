using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class EndingGameController : MonoBehaviour
{
    public GameObject doorOpenCanvas;
    public Animator fade;
    public GameObject CharacterForAnim;
    public GameObject timeline;
    public GameObject mainCamera;
    public GameObject CameraForAnim;
    public GameObject player;
    public AudioSource BGM;
    bool isNext;

    // Start is called before the first frame update
    void Start()
    {
        isNext = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (doorOpenCanvas.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) OpenDoor();
            if (Input.GetKeyDown(KeyCode.Backspace)) NotOpenDoor();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!isNext && (Input.GetKeyDown(KeyCode.P) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            && !doorOpenCanvas.activeSelf)
        {
            GameController.canMove = false;
            StartCoroutine(SetCanvas());
        }
    }

    public void OpenDoor()
    {
        isNext = true;
        StartCoroutine(Movie2());
    }

    public void NotOpenDoor()
    {
        doorOpenCanvas.SetActive(false);
        GameController.canMove = true;
    }

    IEnumerator Movie2()
    {
        doorOpenCanvas.SetActive(false);
        fade.SetBool("fadeout", true);
        yield return new WaitForSeconds(2f);

        CharacterForAnim.SetActive(true);
        CharacterForAnim.transform.rotation = new Quaternion(0, 0, 0, 0);
        CharacterForAnim.transform.position = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(2f);

        BGM.Stop();
        CameraForAnim.SetActive(true);
        mainCamera.SetActive(false);
        Destroy(player);
        timeline.SetActive(true);
        fade.SetBool("fadeout", false);
    }

    IEnumerator SetCanvas()
    {
        yield return null;
        doorOpenCanvas.SetActive(true);
    }
}
