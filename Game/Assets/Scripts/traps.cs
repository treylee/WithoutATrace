using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class traps : MonoBehaviour
{
    // Controls character animation visible to player
    public Animator anim;

   // public AnimationClip anime;
    float waitTime;


    // Start is called before the first frame update
    void Start()
    {
     
        anim = GetComponent<Animator>();

        //REPEAST THE ANIMATION
        InvokeRepeating("animationOn", 1f, 3);
        InvokeRepeating("animationOff", 2f, 3);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void animationOn ()
    {
        anim.SetBool("trap_up", true);
    }

    void animationOff()
    {
        anim.SetBool("trap_up", false);
    }
}
