using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MapCamera : MonoBehaviour
{

    public float zoom = 10F;
    public MaptoLevelTansition obj;

    public float interpVelocity;
    public float minDistance;
    public float followDistance;
    public GameObject target;
    public Vector3 offset;
    Vector3 targetPos;
    private bool startZoom = false;


    public float zoomSpeed = 1;
    public float targetOrtho;
    public float smoothSpeed = 2.0f;
    public float minOrtho = 1.0f;
    public float maxOrtho = 20.0f;


    void Start()
    {
        targetOrtho = Camera.main.orthographicSize;
        targetPos = transform.position;
    }
    void FixedUpdate()
    {
        if (target && obj.startMove) // move camera toward target marker
        {
            Vector3 posNoZ = transform.position;
            posNoZ.z = target.transform.position.z;

            Vector3 targetDirection = (target.transform.position - posNoZ);

            interpVelocity = targetDirection.magnitude * 5f;

            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

            transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.45f);

            startZoom = true;

        }

        if (startZoom) // start zooming
        {
            if (zoom < 15) // scene trans
            {
                SceneManager.LoadScene("Game", LoadSceneMode.Single);

            }else if(zoom < 16) // get rid of marker before scene trans
            {
                target.SetActive(false); 
                zoom--; // trigger scene trans with above if
            }

            else
                zoom -= 0.5f;

            Camera cam = GetComponent<Camera>();
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                targetPos = hit.point;
                cam.transform.position += (targetPos - transform.position) / 5f;

            }
            cam.orthographicSize = zoom;
        }
    }

    void Update()
    {
        float cameraDragSpeed = 150;

        if (obj.startMove == false) // default code for map traversal without marker click
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0 && zoom > 9)
            {
                zoom -= 1;
             
            }

            if (Input.GetAxis("Mouse ScrollWheel") < 0 && zoom < 101)
            {
                zoom += 1;
            
             
            }

            if (Input.GetMouseButton(0))
            {
                float speed = cameraDragSpeed * Time.deltaTime;
                Camera.main.transform.position -= new Vector3(Input.GetAxis("Mouse X") * speed, Input.GetAxis("Mouse Y") * speed, 0);
            }


            Camera.main.orthographicSize = zoom;



        }



    }
}