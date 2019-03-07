using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    public float distance;

    public float rotationSpeed;
    public LineRenderer enemylos1;
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isPatrolling", true);
        anim.SetBool("isFollowing", true);
        Physics2D.queriesStartInColliders = false; // dont detect own

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance);
        if(hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
               // Debug.Log("Hit Player");
             //   Destroy(hitInfo.collider.gameObject);
            }
            enemylos1.SetPosition(1, hitInfo.point);
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
            enemylos1.startColor = Color.red;
        }
        else
        {
            enemylos1.startColor = Color.white;
            Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green);
            enemylos1.SetPosition(1, transform.position + transform.right * distance);
        }
        enemylos1.SetPosition(0, transform.position);
    }
  
}
