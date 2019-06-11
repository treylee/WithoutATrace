using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Patrol : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        patrol = true;
    }
    public EFollow ef;
    public GameObject[] waypoints;
    //public GameObject player;
    int current = 0;
    public float speed;
    float WPradius = 1;
    public bool patrol = true;
    public float movem;
    // Flag indicating orientation of character animation
    private bool faceright;
    void Update()
    {
        /* if(ef.follow== true)
         {
             patrol = false;
         }*/
        //Debug.Log(Vector2.Distance(waypoints[current].transform.position, this.transform.position));
        //Debug.Log("transphorm: " + transform.position);
        if (Vector2.Distance(waypoints[current].transform.position, transform.position) < WPradius)
        {
            current++;
            //current = Random.Range(0, waypoints.Length);
            if (current >= waypoints.Length)
            {
                current = 0;
            }
        }

        if(patrol){

                    this.transform.position = Vector2.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
        }

    }
}
