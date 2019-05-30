using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    public List<GameObject> numbers = new List<GameObject>();
    public int count = 0;
    public int curItem = 0;
    public bool changeItem = false;

    void Start()
    {
        foreach (Transform x in transform)
        {
            numbers.Add(x.gameObject);
        }


    }

    // Update is called once per frame
    float elapsed = 0f;
    void Update()
    {
        

        elapsed += Time.deltaTime;
        if (count < 10)
        {
            if (elapsed >= 2f)
            {
                elapsed = elapsed % 2f;
                OutputTime();
                count++;
            }
        }else
        {
            numbers[numbers.Count-1].SetActive(false);
           // Debug.Log("You Lose");

        }
    }
    void OutputTime()
    {
       //Debug.Log(count);
        if (count > 0)
            numbers[count - 1].SetActive(false);
        numbers[count].SetActive(true);

    }

}
