using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreviewPicture : MonoBehaviour
{
    //private GameObject temp;
    public Image m_Image;
    ////Set this in the Inspector
    public Sprite m_Sprite;
    //protected GameObject temp;


    // Start is called before the first frame update
    void Start()
    {
        m_Image = GetComponent<Image>();
    }

}
