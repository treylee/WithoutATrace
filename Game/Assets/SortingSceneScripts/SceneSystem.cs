using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSystem : MonoBehaviour //this script controls points and animations associated with points
{
    // Start is called before the first frame update
    public CountDown timer; // countdown timer
    public PlayerController player;
    public ItemHandler itemHandler;
    public bool playerHasItem = false;
     GameObject losePopup;
     public GameObject winPopup;
     GameObject plusOne;
     GameObject minusOne;
     GameObject plusTwo;
     GameObject minusTwo;
     GameObject plusThree;
     GameObject minusThree;
     GameObject activePoint;
     bool pointAnimation = false;
    int pointAnimationTimer = 0;


    void Start()
    {
        losePopup = GameObject.FindWithTag("losePopup");
        losePopup.SetActive(false);
        winPopup = GameObject.FindWithTag("winPopup");
        winPopup.SetActive(false);

        plusOne = GameObject.FindWithTag("+1");
        plusOne.SetActive(false);
        minusOne = GameObject.FindWithTag("-1");
        minusOne.SetActive(false);
        plusTwo = GameObject.FindWithTag("+2");
        plusTwo.SetActive(false);
        minusTwo = GameObject.FindWithTag("-2");
        minusTwo.SetActive(false);
        plusThree = GameObject.FindWithTag("+3");
        plusThree.SetActive(false);
        minusThree = GameObject.FindWithTag("-3");
        minusThree.SetActive(false);
        activePoint = plusOne;


    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(timer.count);
        if(timer.count == 10)
        {
            losePopup.SetActive(true);
        }

        if (pointAnimation && pointAnimationTimer < 90)
        {
            activePoint.transform.position = new Vector3(activePoint.transform.position.x, activePoint.transform.position.y + 0.4f, activePoint.transform.position.z);
            pointAnimationTimer++;
           // Debug.Log(pointAnimationTimer);

        }else
        {
            pointAnimation = false;
            activePoint.SetActive(false);
           // minusOne.SetActive(false);
        }
    }
    public void reloadScene()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    public void wrongBin()
    {
        Debug.Log("WrongBin");
        minusOne.SetActive(true);
        minusOne.transform.position = player.transform.position;
        foreach (var x in timer.numbers)
        {
            x.SetActive(false);
        }
        activePoint = minusOne;
        pointAnimation = true;
        pointAnimationTimer = 0;
        timer.count = 0;

    }
    public void correctBin()
    {
        
        plusOne.SetActive(true);
        plusOne.transform.position = player.transform.position;
        foreach (var x in timer.numbers)
        {
            x.SetActive(false);
        }
        activePoint = plusOne;
        pointAnimation = true;
        pointAnimationTimer = 0;
        timer.count = 0;
        Debug.Log("CorrectBin");
        itemHandler.changeItem = true;
        playerHasItem = false;

    }
}
