using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PreviewTitle : MonoBehaviour
{

    //private GameObject temp;
    //public Text m_Title;
    public TextMeshProUGUI m_Title;


    // Start is called before the first frame update
    void Start()
    {
        //Fetch the title from the GameObject
        m_Title = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
