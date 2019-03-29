using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam1;
    public Camera cam2;
    private GameObject target;
    PlayerController player;
    private bool switchedCameras = false;



    private float offset;
    void Start()
    {
        cam1.enabled = true;
        cam2.enabled = false;
        offset = cam2.transform.position.y + transform.position.y;
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<PlayerController>();

        target = GameObject.FindGameObjectWithTag("Floor");



    }

    void Update()
    {
     
        if (switchedCameras == false )
        if (player.moving)
        {
            cam1.enabled = !cam1.enabled;
            cam2.enabled = !cam2.enabled;
            switchedCameras = true;
        }
        if (cam2.enabled && cam2.transform.position.y <= 63f)
        {
            //Debug.Log(cam2.transform.position.y + " " + target.transform.position.y);
            Vector3 temp = new Vector3(cam2.transform.position.x, transform.position.y+20f, cam2.transform.position.z);
            cam2.transform.position = temp;
        }

    }
}