using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoomMove : MonoBehaviour
{
    public Vector2 cameraChange = new Vector2(0.0f, 29.0f);
    public Vector3 playerChange;
    private CameraMovement cam;
    private PlayerController player;
    private Pencil pencil;
    
   //public GameObject 
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        player = p.GetComponent<PlayerController>();

        GameObject pen = GameObject.FindGameObjectWithTag("Pencil");
        pencil = pen.GetComponent<Pencil>();

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
            pencil.one_line = 0;
            player.stopPlayer();


        }

    }
}
