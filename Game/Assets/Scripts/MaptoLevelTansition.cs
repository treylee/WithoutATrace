using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaptoLevelTansition : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    public bool startMove = false;
    private Vector3 offset;
    public Camera mapCamera;

    void Start()
    {
  


    }
    void OnMouseDown()
    {
        // load a new scene
        Debug.Log("down");
        startMove = true;
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
