using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    // Controls speed of the character
    public float speed;

    // Represents body of character
    private Rigidbody2D rb2D;

    // Controls character animation visible to player
    public Animator anim;

    // Contains vertices of line drawn
    private List<Vector3> drawPoints;

    // Index for drawPoints list
    // start at 1 because first add does current position to point
    private int index = 0;

    // Flag indicating whether drawing is enabled
    private bool drawing;

    // Flag indicating whether character is moving
    public bool moving;

    // Controls appearance of line
    LineRenderer lineRenderer;

    // Flag indicating whether character has hit
    // another object
    private bool hitObject;

    //
    private GameObject curItem;

    //
    private GameObject backpack;

    // Accesses Pencil module (another file)
    Pencil p;

    // Controls incomplete-line popup
    public GameObject panel;

    public GameObject panel_hole;
    //
    public float step;

    // Flag indicating orientation of character animation
    private bool faceright;

    // 
    public float movem;
    
    // Flag indicating 
    private bool pickup;
    
    

    //Flag indicating whether player is stopped
    public bool stop;
    public bool busy; // if engaged in dialog cannot move;
    private void Start()
    {
        movem = 0;
        stop = false;
        speed = 0;
        moving = false;
        drawing = false;
        hitObject = false;
        busy = false; 

        // Fetches components from this file
        // (Set in inspector)
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();

       // panel = GameObject.FindGameObjectsWithTag("Trap_popup");

        // Fetches Pencil module (another file)
        GameObject pencil = GameObject.FindGameObjectWithTag("Pencil");

        // Fetches backpack module (another file)
        backpack = GameObject.FindGameObjectWithTag("Backpack");

        // Copies/transfers settings from Pencil module
        lineRenderer = pencil.GetComponent<LineRenderer>();
        p = pencil.GetComponent<Pencil>();
        drawPoints = p.drawPoints;
        drawing = p.drawing;

        // Miscellaneous Actions 
        // faceright = true;
        // backpack.transform.LookAt(Camera.main.transform.position); // make face camera so doesnt flip
    }

    // Handles character movement at instant of collision
    // with non-item object
    private void OnTriggerEnter2D(Collider2D other)
    {
        Animator a = other.GetComponent<Animator>();

        // collision with wall
        if (other.gameObject.name.Equals("warehouse_1f_walls"))
        {
            SpriteRenderer r = other.gameObject.GetComponent<SpriteRenderer>();
            r.sortingOrder = 20;
            stopPlayer();
        }
     
     // collision with trap
        if(other.gameObject.tag.Equals("Trap"))
        {
            if (a.GetBool("trap_up"))
            {
                //Debug.Log("Traps work");
                panel.SetActive(true);
                stopPlayer();
               
            }
        }

        if (other.gameObject.tag.Equals("hole"))
        {
            
                //Debug.Log("Traps work");
                panel_hole.SetActive(true);
                stopPlayer();  
        }
    }

    // Handles character movement through duration 
    // of collision with non-item object
    private void OnTriggerStay2D(Collider2D other)
    {
        Animator a = other.GetComponent<Animator>();
        // Debug.Log("trigger");
        if (other.gameObject.name.Equals("warehouse_1f_walls"))
        {
           curItem = other.gameObject;
           stopPlayer();
            
        }
        if (other.gameObject.tag.Equals("Trap"))
        {
            if (a.GetBool("trap_up"))
            {
                //Debug.Log("Traps work");
                panel.SetActive(true);
                stopPlayer();

            }
        }


    }

    // Handles character movement at end of collision
    // with non-item object 
    private void OnTriggerExit2D(Collider2D other)
    {
        Animator a = other.GetComponent<Animator>();
        if (other.gameObject.name.Equals("warehouse_1f_walls"))
        {
            SpriteRenderer r = other.gameObject.GetComponent<SpriteRenderer>();
            r.sortingOrder = 3;
            stopPlayer();
        }

        if (other.gameObject.tag.Equals("Trap"))
        {
            if (a.GetBool("trap_up"))
            {
                //Debug.Log("Traps work");
                panel.SetActive(true);
                stopPlayer();

            }
        }
    }

    private void Update()
    {
        //setAnime();

        if (drawPoints.Count != 0 && !busy)
        {
            if (p.drawing == false )
            {
                moving = true;
                setAnime();
                if (movem > transform.position.x && !faceright)
                {
                    flip();

                }
                else if (movem < transform.position.x && faceright)
                {
                    flip();
                }
                else { }
                movem = transform.position.x;
                
                step = speed * Time.deltaTime;
                //Debug.Log(index);

                /*if (anim.GetCurrentAnimatorStateInfo(0).IsName("grab") && hitObject == true)
                {
                    // do something
                    Debug.Log("aliiiiiiiiiiiiiiiiiiiiii");
                    stop = false;
                    // hitObject = false;
                }*/
                setAnime();
                // drawPoints[index].z = 12;
                if (stop == false)
                {
                    transform.position = Vector3.MoveTowards(transform.position, drawPoints[index], step);

                    if (Vector3.Distance(transform.position, drawPoints[index]) < 0.1f)
                    {
                        index++;
                        // Debug.Log("moving");
                        //lineRenderer.SetPosition(1, drawPoints[index]); 
                    }
                }
               //if (movem < 0) GetComponent<Rigidbody2D>().velocity = new Vector3(movem * speed, GetComponent<Rigidbody2D>().velocity.y);
               //if(movem > 0) GetComponent<Rigidbody2D>().velocity = new Vector3(movem * speed, GetComponent<Rigidbody2D>().velocity.y);


               // if (movem < 0 && faceright) flip();
                //if (movem > 0 && !faceright) flip();

            }

            if (Vector3.Distance(transform.position, drawPoints[drawPoints.Count - 1]) < 0.1f)
            {
                //Debug.Log("dead");
                //lineRenderer.SetPositions(new Vector3[0]);
              


                stopPlayer();
                
            }
           
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            for (int i = 0; i < drawPoints.Count-1; i++)
            {
                //Debug.Log(drawPoints[i]);
                lineRenderer.positionCount = 0;
            }
        }

        // Changes speed of character movement
        if (Input.GetMouseButton(0) && moving)
        {
            if (Input.GetAxis("Mouse Y") < 0 && !Inventory_Button.isPaused)
            {
                //Code for action on mouse moving down
                if (speed > 1)
                    speed--;
                else
                    speed = 2;
               
            }
            if (Input.GetAxis("Mouse Y") > 0 && !Inventory_Button.isPaused)
            {
                //Code for action on mouse moving up
                if (speed > 1)
                    speed++;
                else
                    speed = 2;
            }

        }
    }

    // Handles orientation of character animation
    void flip()
    {
        faceright = !faceright;
        transform.Rotate(Vector3.up * 180);
    }

    // Handles change in character animation from
    // moving to idle
    private void setAnime()
    {
        if (speed == 0 && hitObject == false)
        {
          //  Debug.Log("its IDLE");
            //Debug.Log("speed is " + speed);

            anim.SetBool("idle",true);

            anim.SetBool("walking", false);
            anim.SetBool("running", false);
            anim.SetBool("turn", false);
            anim.SetBool("grab", false);
            //anim.SetBool("walking", false);

        }
        else if(speed > 13 && hitObject == false)
        {
            anim.SetBool("running", true);
            anim.SetBool("walking", false);
        }
        
        if(speed <= 13 && speed > 0 && hitObject == false)
        {
            anim.SetBool("idle", false);
            anim.SetBool("walking", true);
            anim.SetBool("running", false);
            anim.SetBool("grab", false);

        }
    }

    // Handles stopping "motion" of character animation
    // throughout collision with another object
    public void stopPlayer()
    {
        lineRenderer.positionCount = 0;
        index = 0;
        speed = 0;
        setAnime();
        drawPoints.Clear();
     
        moving = false;
        p.firstPoint = 0;
    }
}
