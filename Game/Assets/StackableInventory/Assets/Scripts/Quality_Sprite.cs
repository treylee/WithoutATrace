using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quality_Sprite : MonoBehaviour
{
    public Image m_Quality;

    // Start is called before the first frame update
    void Start()
    {
        //Fetch the quality from the GameObject
        m_Quality = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
