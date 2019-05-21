using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 

public class EFollow : MonoBehaviour
{
    public Transform target;
    public float speed;
	public bool follow = false;

    public float rotationSpeed;
    public float distance;

    public  GameObject enemy;
    public Patrol p;

    public float movem;
    // Flag indicating orientation of character animation
    private bool faceright;




    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        p = enemy.GetComponent<Patrol>();
    }


            // Update is called once per frame
    void Update()
    {

        movem = transform.position.x;

        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime); 

       RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance);

        if (movem > transform.position.x && !faceright)
        {
            hitInfo = Physics2D.Raycast(transform.position, transform.right, distance);
            flip();

        }
        else if (movem < transform.position.x && faceright)
        {
            hitInfo = Physics2D.Raycast(transform.position, transform.right, distance);

            flip();
        }
        else { }
        if (hitInfo.collider != null)
       {

            if(hitInfo.collider.CompareTag("Player"))
            {
                Debug.Log("Player tag detected");
                p.patrol = false;
                follow = true;
                
                speed = 15;
                //speed = p.speed * 2;
            }
       } 
       else
       {

            Debug.DrawLine(transform.position, transform.position + transform.right * distance);

       }

      if (follow){

            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        }

    }
    void flip()
    {
        faceright = !faceright;
        transform.Rotate(Vector3.up * 180);
    }
}
