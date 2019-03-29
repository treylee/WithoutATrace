using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Pencil : MonoBehaviour
{
    Touch touch;
    private Vector3 position;
    private float width;
    private float height;

    bool continueLine;

    // List of vectors to hold vertices of line drawn
    public List<Vector3> drawPoints = new List<Vector3>();

    // Flag indicating whether drawing is occuring
    public bool drawing;

    //private Transform playerPos;

    // Line drawn by player
    LineRenderer line;

    //
    public int firstPoint = 0;

    // Flag controlling whether player can draw line
    public bool canDraw = false;

    //
    GameObject player;

    // Pop up for incomplete (not to an exit) line
    public GameObject exit_popup;

    // Character
    PlayerController p;

    //UnityEngine.CharacterController p;

    //
    private Material m1, m2;

    // Flag indicating whether Start() has occurred
    bool start;

    //
    bool line_material;

    // Ensures only one line can be drawn per dungeon
    public int one_line;
    
    void Start()
    {
        // Flag indicates drawing is not occuring
        drawing = false;

        //
        line_material = true;

        m1 = Resources.Load("line2", typeof(Material)) as Material;
        m2 = Resources.Load("line", typeof(Material)) as Material;
        //Material newMat = Resources.Load("DEV_Orange", typeof(Material)) as Material;
        
        line = gameObject.GetComponent<LineRenderer>();

        // Ensures line appears above dungeon screen layer
        line.sortingOrder = 2;

        // 
        player = GameObject.FindGameObjectWithTag("Player");

        // 
        p = player.GetComponent<PlayerController>();

        // Flag disables player's ability to draw line
        canDraw = false;

        continueLine = false;

        //panel = GameObject.Find("line_incompelete_panel");

        // Resets line count
        one_line = 0;

        //line.positionCount = 1;
        //line.material = m1;

        // Set line's size
        line.startWidth = 0.5f;
        line.endWidth = 0.5f;

        // line.startColor = Color.white;
        // line.endColor = Color.white;

        //
        firstPoint = 0;

        // playerPos = GameObject.FindGameObjectWithTag("Player").transform;

        start = false;
    }

    // Update is called once per frame
    void Update()
    {
        // No line has been drawn yet for that dungeon
        if (one_line == 0)
        {
            // Character is not moving
            if (Input.GetMouseButton(0) && !p.moving)
            {
                // Flag indicates drawing is occuring 
                drawing = true;

                // Flag enables player's ability to draw line
                canDraw = true;

                // Get mouse postion
                Vector3 mouse = Input.mousePosition;
                Vector3 castPoint = Camera.main.ScreenToWorldPoint(mouse);

                // Arbitrary value for z-axis required for Unity
                castPoint.z = 5;

                float radius = 3.00f;


                //Debug.Log("Held");
                //Vector2 mouseposition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                Vector3 ppos = player.transform.position;
                start = true;
                //Vector3 objposition = Camera.main.ScreenToWorldPoint(mouseposition);

                // Checks if line is drawn starting from character
                /*
                if (ppos.x <= castPoint.x + 1.2 && ppos.x >= castPoint.x - 1.5 && ppos.y <= castPoint.y + 1 && ppos.y >= castPoint.y - 3)
                {
                    start = true;
                }
                */

                    /*
                    if (Input.touches.any(x => x.phase == TouchPhase.Began)
                    {
                        touch = Input.GetTouch(Input.touchCount - 1);
                        touch.radiusVariance = 3;
                        start = true;
                        Debug.Log("Touchdown!!!");
                    }
                    */

                    if (Vector2.Distance(castPoint, ppos) < radius)
                    {
                        // Mouse is inside the circle with the center and radius.
                        if (!drawPoints.Contains(castPoint) && start)
                        {

                            // Add mouse position to list of vectors
                            drawPoints.Add(castPoint);

                            // Increase number of vertices in line
                            line.positionCount++;

                            // Set vertex 0 to that of mouse position
                            line.SetPosition(line.positionCount - 1, castPoint);

                        }

                        //Set flag to continue drawing line,
                        //if it was started w/in radius of
                        //character
                        continueLine = true;
                    }
                    else
                    {
                        if (continueLine)
                        {
                            // Add mouse position to list of vectors
                            drawPoints.Add(castPoint);

                            // Increase number of vertices in line
                            line.positionCount++;

                            // Set vertex 0 to that of mouse position
                            line.SetPosition(line.positionCount - 1, castPoint);
                        }
                        else
                        {

                            // Mouse is outside the circle area
                            Debug.Log("Not in radius of player");

                        }
                    }

            }
            /*
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 pos = touch.position;
                pos.x = (pos.x - width) / width;
                pos.y = (pos.y - height) / height;
                position = new Vector3(-pos.x, pos.y, 5);

                // Position the cube.
                ppos = position;
            }
            */

            //start = true;
            //transform.position = objposition;

            else if (Input.GetMouseButtonUp(0))
            {
                // Increases drawn line count
                one_line++;


                if (drawing && !p.moving)
                {
                    // player.speed = 10;
                    p.speed = 10;

                    // Flag indicates drawing is not occuring
                    drawing = false;

                    // Debug.Log("Drawing is now false");


                    start = false;
                    // line.positionCount = 0;

                }

                //exit_popup.SetActive(true);
            }

        }
            
            // Checks if left mouse button (0 button) is released
            
        }
    }

   /* void drawLine()
    {
     

        for (int i = 0; i < drawPoints.Count; i++)
        {
            line.positionCount++;
            line.SetPosition(i, drawPoints[i]);

        }
       // line.positionCount--;
        //firstPoint = 0;
        canDraw = false;
    }*/
