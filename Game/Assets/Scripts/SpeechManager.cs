using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeechManager
    : MonoBehaviour
{
    public int storyPoint = -1;
    public PlayerController player;
    public GameObject textPanel;
    [TextArea(3,20)]
    public string[] textList;
    public Queue<string> dialog;
    public TextMeshProUGUI text;
    public GameObject continueButton;
    public GameObject currentGameObject;
    public List<GameObject> plastics;
    //public Transform[] plastics;
    public bool shouldDestroyAfterInteraction;
    public bool shouldMovetoPlayer;
  

    // Start is called before the first frame update
    void Start()
    {
         
      
    }

    // Update is called once per frame
    void Update()
    { /*
        if (shouldMovetoPlayer)
        {
            GetComponent<Renderer>().enabled = false;
            transform.position = player.transform.position;
            shouldMovetoPlayer = false;
            /*
            float step = 10.0f * Time.deltaTime; // calculate distance to move

            // Check if the position of the cube and sphere are approximately equal.
            if (Vector3.Distance(transform.position, player.transform.position) > 0.1f)
            {
                // Swap the position of the cylinder.
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
            }
            
        }
    */
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Player"))
        {
            Debug.Log("Talking to ol man");
            textPanel.SetActive(true);
           // continueButton.SetActive(true);
            getDialog();
            player.stopPlayer();
            player.busy= true;
            
        }
    }
    public int counter = -1;
    public void getDialog()
    {
        
        Debug.Log("THE SPEECH MANAGER IS WORKING"+storyPoint+"////"+counter);
        
        if (counter == storyPoint)
        {
            Debug.Log("got here" + storyPoint);

            textPanel.SetActive(false);
            continueButton.SetActive(false);
            if (shouldDestroyAfterInteraction)
            {
                currentGameObject.SetActive(false);
                Debug.Log("the name of object: " + currentGameObject.gameObject.name);
                
            }
            player.busy = false;
            return;
        }

         //text.text = textList[++storyPoint];
        StopAllCoroutines();
        StartCoroutine(TypeSentence(textList[storyPoint]));

    }
    IEnumerator TypeSentence(string sentence)
    {
        counter++;
        text.text = "";
        int count = 0;
          //continueButton.SetActive(false);
        for( int i = 0; i < textList[counter].Length; i++)
        {
            text.text += textList[counter][count++];
            yield return null;
        }
        continueButton.SetActive(true);

        //storyPoint++;
    }


}