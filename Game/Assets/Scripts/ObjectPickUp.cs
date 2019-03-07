using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickUp : MonoBehaviour
{
    private bool pickUp;
    private Animator an;
    
    public GameObject playeranime;
    PlayerController pp;
    // Start is called before the first frame update
    void Start()
    {
        pickUp = false;
        playeranime = GameObject.FindGameObjectWithTag("Player");
        //anim = playeranime.GetComponent<Animator>();
        pp = playeranime.GetComponent<PlayerController>();
        //an = pp.anim;
    }

    // Update is called once per frame
    void Update()
    {
        if(pickUp)
        {
            pickUpItem();
            /*if (this.pp.anim.GetCurrentAnimatorStateInfo(0).IsName("grab"))
            {
                Debug.Log("nooooooooooooooooooooooootttttttttttt stayingggggggggggggggg");

                // pp.anim.SetBool("grab", false);
                // pp.anim.SetBool("walking", true);
            }*/
            pickUp = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
     {
         Debug.Log("trigger");
         
         SpriteRenderer r = other.gameObject.GetComponent<SpriteRenderer>();
         r.sortingOrder = 20;

     }
     private void OnTriggerExit2D(Collider2D other)
     {
        Debug.Log("trigger");

        //Debug.Log("trigger");
        SpriteRenderer r = other.gameObject.GetComponent<SpriteRenderer>();
         r.sortingOrder = 3;
     }
    
    //after we left the item do the following
     private void OnTriggerExit(Collider other)
     {
         Debug.Log("triggerrrr exit =========================");
          if (other.gameObject.name.Equals("Player"))
          {
              Debug.Log("Its the player =========================");
              pickUp = false;
          }
   // pp.anim.SetBool("grab", false);
    }

   void OnCollisionEnter2D(Collision2D collision)
   {
        if (collision.gameObject.name.Equals("Player"))
        {
            Debug.Log("Its the player enter =========================");
           // pp.stop = true;
           // pp.moving = false;
            pickUp = true;
            
            // pickUpItem();
        }

        //  Destroy(collision.gameObject);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
       Debug.Log("grab = false ========");
       //pp.anim.SetBool("grab", false);
       // pp.anim.SetBool("")
       //anim.SetBool("walking", true);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("stayingggggggggggggggg");
        if(this.pp.anim.GetCurrentAnimatorStateInfo(0).length < pp.anim.GetCurrentAnimatorStateInfo(0).normalizedTime)
        {
            Debug.Log("nooooooooooooooooooooooootttttttttttt stayingggggggggggggggg");

           // pp.anim.SetBool("grab", false);
           // pp.anim.SetBool("walking", true);
        }

    }
    //this is where pickup animation happens and we put the item
    //into the bagpack
    void pickUpItem()
    {
        //pp.speed = 0;
      
        pp.anim.SetBool("grab", true);
        pp.anim.SetBool("walking", false);
        pp.anim.SetBool("running", false);
        //for (int i = 0; i < 9000; i++)
        //{ Debug.Log("//test"); }
       /*while(pp.anim.GetCurrentAnimatorStateInfo(0).IsName("grab"))
       {
           
       }*/
        //pp.anim.SetBool("running", true);
        //anim.SetBool("running", false);
        //gameObject.SetActive(false);
        //Destroy(gameObject);
       // pickUp = false;
    }
    
}
