using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0));

        float middlePointX = v.x / 2;
        float middlePointY = v.y / 2;

        transform.position = new Vector3(Screen.width * 0.5f, Screen.height / 12, 0);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag.Equals("Item"))
        {
            Debug.Log("Picked up an Item"+other.gameObject.name);

        }

    }
}
