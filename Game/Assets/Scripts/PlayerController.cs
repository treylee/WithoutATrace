using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;

    private Rigidbody2D rb2D;
    public Animator anim;
    private List<Vector3> drawPoints;
    private int index = 0; // start at 1 because first add does current position to point
    private Vector3 oldpos;
    private bool drawing;
    public bool moving;
    LineRenderer lineRenderer;
    private Animator animator;
    private bool hitObject;
    //private bool grabbingItem;
    private GameObject curItem;
    private GameObject backpack;
    Pencil p;
    public GameObject panel;

    public float step;
    private bool faceright;
    public float movem;
    private bool pickup;
    public bool stop;
    
    //private int itemScale = 0;

    private void Start()
    {
        //faceright = true;
        movem = 0;
        stop = false;
        animator = GetComponent<Animator>();
      
        speed = 0;
        moving = false;
        drawing = false;
        //grabbingItem = false;
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        GameObject pencil = GameObject.FindGameObjectWithTag("Pencil");
        backpack = GameObject.FindGameObjectWithTag("Backpack");
        //backpack.transform.LookAt(Camera.main.transform.position); // make face camera so doesnt flip

        lineRenderer = pencil.GetComponent<LineRenderer>();
        p = pencil.GetComponent<Pencil>();
        drawPoints = p.drawPoints;
        drawing = p.drawing;
        hitObject = false;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("trigger");
        if (other.gameObject.name.Equals("warehouse_1f_walls"))
        {
            SpriteRenderer r = other.gameObject.GetComponent<SpriteRenderer>();
            r.sortingOrder = 20;
        }
 

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("trigger");
        if (other.gameObject.name.Equals("warehouse_1f_walls"))
        {
           curItem = other.gameObject;
           // grabbingItem = true;


        }
    
  
    }

        private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("warehouse_1f_walls"))
        {
            SpriteRenderer r = other.gameObject.GetComponent<SpriteRenderer>();
            r.sortingOrder = 3;
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {


        //  Destroy(collision.gameObject);
    }
    void OnCollisionStay2D(Collision2D collision)
    {


        if (collision.gameObject.name.Equals("warehouse_1f_walls"))
            stopPlayer();
        // else if (collision.gameObject.name.Equals("GlassBottle"))
        /*if (!anim.GetCurrentAnimatorStateInfo(0).IsName("grab"))
        {
            hitObject = false;
            stop = false;
        }   */ 

    }

    private void Update()
    {
        //setAnime();

        if (drawPoints.Count != 0)
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
                if(p.one_line > 0)
                panel.SetActive(true);


                stopPlayer();
                
            }
           
        }
        /*
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = moveInput.normalized * speed;

        if (moveInput != Vector2.zero)
        {
            anim.SetBool("isRunning", true);
        }
        else {
            anim.SetBool("isRunning", false);
        }
            */

        if (Input.GetKeyDown(KeyCode.L))
        {
            for (int i = 0; i < drawPoints.Count-1; i++)
            {
                //Debug.Log(drawPoints[i]);
                lineRenderer.positionCount = 0;
            }
        }

        if (Input.GetMouseButton(0) && moving)
        {
            if (Input.GetAxis("Mouse Y") < 0)
            {
                //Code for action on mouse moving down
                if (speed > 1)
                    speed--;
                else
                    speed = 2;
               
            }
            if (Input.GetAxis("Mouse Y") > 0)
            {
                //Code for action on mouse moving up
                if (speed > 1)
                    speed++;
                else
                    speed = 2;
            }

        }
    }
    void flip()
    {
        faceright = !faceright;
        transform.Rotate(Vector3.up * 180);
    }
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
       /*  if (hitObject == true)
        {
            //speed = 0.3f;
            anim.SetBool("grab", true);
            //speed ++;
            anim.SetBool("walking", false);
            anim.SetBool("running", false);
            anim.SetBool("idle", false);
            //if animation with name "Attack" finished
            

            // stop = false;
            // hitObject = false;
            // anim.SetBool("turn", false);
            //hitObject = false;
        }        //  Destroy(collision.gameObject);
        */
    }



    public void Hi()
    {
        Debug.Log("HIHIHIIHIHIHIHI");
    }

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
