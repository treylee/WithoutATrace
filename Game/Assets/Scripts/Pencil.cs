using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pencil : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Vector3> drawPoints = new List<Vector3>();
    public bool drawing;
    //private Transform playerPos;
    LineRenderer line;
    public int firstPoint = 0;
    public bool canDraw = false;
    GameObject player;
    PlayerController p;
    private Material m1, m2;
    bool start ;
    bool line_material;
    void Start()
    {
        drawing = false;
        line_material = true;
        m1 = Resources.Load("line2", typeof(Material)) as Material;
        m2 = Resources.Load("line", typeof(Material)) as Material;
            //Material newMat = Resources.Load("DEV_Orange", typeof(Material)) as Material;
        line = gameObject.GetComponent<LineRenderer>();
        line.sortingOrder = 2;
         player = GameObject.FindGameObjectWithTag("Player");
        p = player.GetComponent<PlayerController>();
        canDraw = false;
        //line.positionCount = 1;
        //line.material = m1;

        line.startWidth = 0.5f;
        
        line.endWidth = 0.5f;
       // line.startColor = Color.white;
       // line.endColor = Color.white;
        firstPoint = 0;
        // playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        start = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButton(0) && !p.moving)
        {
            drawing = true;
            canDraw = true;

            Vector3 mouse = Input.mousePosition;
            Vector3 castPoint = Camera.main.ScreenToWorldPoint(mouse);
            castPoint.z = 5;
           

            //Debug.Log("Held");
            Vector2 mouseposition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector3 ppos = player.transform.position;//Vector3 objposition = Camera.main.ScreenToWorldPoint(mouseposition);
            if (ppos.x <= castPoint.x + 1.2 && ppos.x >= castPoint.x - 1.2 && ppos.y <= castPoint.y + 1 && ppos.y >= castPoint.y - 3)
            {
                start = true;
            }
            //transform.position = objposition;
           
            if (!drawPoints.Contains(castPoint) && start)
            {
            
                drawPoints.Add(castPoint);
                line.positionCount++;
             
                line.SetPosition(line.positionCount - 1, castPoint);
        
            }


        }
        else
        {
            if (drawing && !p.moving)
            {
                // player.speed = 10;
                p.speed = 10;
                drawing = false;

                // Debug.Log("Drawing is now false");
                start = false;
               // line.positionCount = 0;

            }
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
}
