using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkLift : MonoBehaviour
{
    // Start is called before the first frame update
    private bool move = false;
    public float speed = 0.7f;
    void Start()
        
    {
        move = true;
    }    

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            Vector3 temp = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
            transform.position = temp;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {


        if (collision.gameObject.tag.Equals("Player"))

            move = false;

        }
}
