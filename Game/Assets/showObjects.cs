using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showObjects : MonoBehaviour
{
    public List<GameObject> revealedObjects;
    public SpeechManager speechManager;
    public int currentStoryPoint;
    bool getNextDialog = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    int timer = 0;
    void Update()
    {
        
        if (getNextDialog)
        {
            timer++;
            
            if(timer == 60)
            {
                Debug.Log("timer is 100");
                showDialog();
                getNextDialog = false;
                timer = 0;
            }
        }
    }
    void showDialog()
    {

        speechManager.shouldMovetoPlayer = true;
        speechManager.textPanel.SetActive(true);
        // continueButton.SetActive(true);
        speechManager.getDialog();
        speechManager.player.stopPlayer();
        speechManager.player.busy = true;


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Player"))
        {
            Debug.Log("entered");
           foreach(GameObject obj in revealedObjects)
            {
                obj.SetActive(true);
                
            }
            speechManager.storyPoint = currentStoryPoint;
            if (currentStoryPoint != 3)
            {
                getNextDialog = true;
                //speechManager.shouldMovetoPlayer = true;
            }
            /*
            if (currentStoryPoint != 3)
            { //not start node
                speechManager.shouldMovetoPlayer = true;
                speechManager.textPanel.SetActive(true);
                // continueButton.SetActive(true);
                speechManager.getDialog();
                speechManager.player.stopPlayer();
                speechManager.player.busy = true;
            }
            */
        }
    }
}
