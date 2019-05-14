using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherModel : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("s");
        if(collision.gameObject.tag == "Player"){
            Launch.hasLauncher = true;
            Launch.isLaunched = false;
            GenerateEnemy.launcherNum--;
            Destroy(gameObject);
        }
    }
}
