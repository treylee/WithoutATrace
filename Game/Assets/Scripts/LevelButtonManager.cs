using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButtonManager : MonoBehaviour
{
    public void Restart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void home()
    {
        SceneManager.LoadScene(0);
    }

    public void Inventory()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
