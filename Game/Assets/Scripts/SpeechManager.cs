using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeechManager
    : MonoBehaviour
{
    private int storyPoint = 0;
    public PlayerController player;
    public GameObject textPanel;
    [TextArea(3,20)]
    public string[] textList;
    public Queue<string> dialog;
    public TextMeshProUGUI text;
    public GameObject continueButton;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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

    public void getDialog()
    {
        Debug.Log("THE SPEECH MANAGER IS WORKING"+storyPoint);

        if (textList.Length == storyPoint)
        {
            Debug.Log("got here" + storyPoint);

            textPanel.SetActive(false);
            continueButton.SetActive(false);
            player.busy = false;
            return;
        }

         //text.text = textList[++storyPoint];
        StopAllCoroutines();
        StartCoroutine(TypeSentence(textList[storyPoint]));

    }
    IEnumerator TypeSentence(string sentence)
    {
        text.text = "";
        int count = 0;
          //continueButton.SetActive(false);
        for( int i = 0; i < textList[storyPoint].Length; i++)
        {
            text.text += textList[storyPoint][count++];
            yield return null;
        }
        continueButton.SetActive(true);

        storyPoint++;
    }


}