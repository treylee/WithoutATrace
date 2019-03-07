using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMove : MonoBehaviour
{
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovement cam;
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        player = p.GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {

    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.name);
        //Debug.Log("Detects collision");
        if (other.name == ("Player"))
        {
            //Debug.Log("Detects collision with tag 'player'");
            cam.minPosition += cameraChange;
            cam.maxPosition += cameraChange;
            other.transform.position += playerChange;
            player.stopPlayer();

        }

    }
}
