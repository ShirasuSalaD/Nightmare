using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoEndroll : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(toEndroll());
    }

    IEnumerator toEndroll()
    {
        yield return new WaitForSeconds(2f);
        //エンドロールに移行
        SceneManager.LoadScene("EndrollScene");
    }
}
