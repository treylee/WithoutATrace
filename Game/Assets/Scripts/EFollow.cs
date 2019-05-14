using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 

public class EFollow : MonoBehaviour
{
    public Transform target;
    public float speed;
	public bool follow;

    public float rotationSpeed;
    public float distance;

    public Patrol p;




    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


            // Update is called once per frame
    void Update()
    {

       transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime); 

       RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance);
    
       if(hitInfo.collider != null)
       {

            if(hitInfo.collider.CompareTag("Player"))
            {
                Debug.Log("Player tag detected");
                follow = true;
                p.patrol = false;
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

}
