using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



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
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("sdsa");
        SceneManager.LoadScene("Game", LoadSceneMode.Single);

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
