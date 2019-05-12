using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDescription : MonoBehaviour
{
    //private GameObject temp;
    public Text m_Description;


    // Start is called before the first frame update
    void Start()
    {
        //Fetch the title from the GameObject
        m_Description = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
