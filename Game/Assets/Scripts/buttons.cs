using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class buttons : MonoBehaviour
{
    public void play_game()
    {

        SceneManager.LoadScene(1);
    }
    public void back()
    {

        SceneManager.LoadScene(0);
    }
    public void credit()
    {

        SceneManager.LoadScene(2);
    }
    public void options()
    {

        SceneManager.LoadScene(3);
    }

}
