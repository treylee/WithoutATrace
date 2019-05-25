using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardTitle : MonoBehaviour
{
    public Text m_Title;


    // Start is called before the first frame update
    void Start()
    {
        //Fetch the title from the GameObject
        m_Title = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
