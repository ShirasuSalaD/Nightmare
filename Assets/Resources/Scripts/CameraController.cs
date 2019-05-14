using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    Transform targetTransform;
    float smooth = 10f;
    Vector3 offset;

    // Start is called before the first frame update
    void OnEnable()
    {
        targetTransform = player.transform;
        transform.position = targetTransform.position + new Vector3(0, 2, -2);
        offset = transform.position - targetTransform.position;

        //transform.position = targetTransform.position + offset;
        //transform.forward = targetTransform.forward;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, targetTransform.position + offset, Time.deltaTime * smooth);
        //transform.forward = Vector3.Lerp(transform.forward, targetTransform.forward, Time.deltaTime * smooth);
    }
}
