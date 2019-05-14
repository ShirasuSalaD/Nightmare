using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour{

    //GameObject shell;
    AudioSource audiosource;
    public AudioClip bulletSE;
    public AudioClip machineGunSE;
    public AudioClip reloadSE;
    public AudioClip launcherSE;
    float deltaTime;
    bool isReloading = true;
    bool isShooting = false;
    bool isFoucsed = false;
    public static bool hasLauncher;
    public static bool isLaunched;

    public GameObject Gun;
    public GameObject Launcher;
    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        Gun = GameObject.FindWithTag("gun");
        Launcher = GameObject.FindWithTag("launcher");
    }

    // Update is called once per frame
    void Update() {
        //Debug.Log(isLaunched);
        if (hasLauncher == true)
        {
            Gun.SetActive(false);
            Launcher.SetActive(true);
            if (Input.GetKeyDown(KeyCode.O) || Input.GetButtonUp("Fire1"))
            {
                if (isFoucsed)
                {
                    isFoucsed = false;
                }
                else
                {
                    isFoucsed = true;
                }
            }
            if((Input.GetKey(KeyCode.P) || Input.GetButton("Fire2")) && isFoucsed && !isLaunched){
                //Vector3 LaunchPosition = new Vector3(0.0f, 1.0f, 0.0f);
                Vector3 bulletPosition = gameObject.transform.position;
                // 弾丸の複製
                //GameObject bullets = Instantiate(Sphere) as GameObject;
                GameObject shell = (GameObject)Resources.Load("Prefabs/Bullet");
                shell = Instantiate(shell, bulletPosition, Quaternion.identity);
                shell.transform.rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));

                Vector3 force;

                force = this.gameObject.transform.forward * 5000;

                // Rigidbodyに力を加えて発射
                shell.GetComponent<Rigidbody>().AddForce(force);
                isLaunched = true;
                audiosource.PlayOneShot(launcherSE);

                Destroy(shell, 5f);
            }
        }
        else
        {
            Gun.SetActive(true);
            Launcher.SetActive(false);
            if (Input.GetKeyDown(KeyCode.O) || Input.GetButtonUp("Fire1"))
            {
                if (isFoucsed)
                {
                    isFoucsed = false;
                }
                else
                {
                    isFoucsed = true;
                }
            }
            deltaTime += Time.deltaTime;
            if (deltaTime >= 0.2f)
            {
                audiosource.Stop();
                deltaTime = 0f;
            }
            else if (deltaTime >= 0.1f)
            {
                if ((Input.GetKey(KeyCode.P) || Input.GetButton("Fire2")) && isFoucsed)
                {
                    if (audiosource.isPlaying)
                    {
                        if (isShooting)
                        {
                            //Vector3 LaunchPosition = new Vector3(0.0f, 1.0f, 0.0f);
                            Vector3 bulletPosition = gameObject.transform.position;
                            // 弾丸の複製
                            //GameObject bullets = Instantiate(Sphere) as GameObject;
                            GameObject shell = (GameObject)Resources.Load("Prefabs/tama");
                            shell = Instantiate(shell, bulletPosition, Quaternion.identity);

                            Vector3 force;

                            force = this.gameObject.transform.forward * 5000;

                            // Rigidbodyに力を加えて発射
                            shell.GetComponent<Rigidbody>().AddForce(force);

                            Destroy(shell, 1f);
                        }
                    }
                    else
                    {

                        if (isShooting)
                        {
                            audiosource.PlayOneShot(reloadSE);
                            isReloading = true;
                            isShooting = false;
                        }
                        else if (isReloading)
                        {
                            audiosource.PlayOneShot(machineGunSE);
                            isShooting = true;
                            isReloading = false;
                        }

                    }


                    //shell.transform.position = muzzle.position;
                    deltaTime = 0;
                }
            }
        }
    }
}
