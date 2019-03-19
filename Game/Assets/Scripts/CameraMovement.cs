using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;

    private Pencil pencil;
    private LineRenderer line;

    public float smoothing;
    public Vector2 maxPosition = new Vector2(0.0f, 29.0f);
    public Vector2 minPosition = new Vector2(0.0f, 29.0f);

    // Start is called before the first frame update
    void Start()
    {
        /*GameObject pen = GameObject.FindGameObjectWithTag("Pencil");
        line = pen.GetComponent<LineRenderer>();
        pencil = pen.GetComponent<Pencil>();
        */
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x -2.2f, maxPosition.x-2.2f);

            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y+10.6f, maxPosition.y+10.6f);

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
            
        }
    }
}
