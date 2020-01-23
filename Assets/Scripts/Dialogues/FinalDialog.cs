using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalDialog : MonoBehaviour
{
    public GameObject player;
    public GameObject canvas;
    public GameObject baba;
    public GameObject chop; 
    bool enter = false;
    bool activated;
    int counter;

    public GameObject plague;

    Text dialog;

    LevelTransition levelTransition;

    public GameObject cdnText;

    void Start()
    {
        levelTransition = FindObjectOfType<LevelTransition>();
        enter = false;
        // canvas.GetComponent<Canvas>().enabled = false;
        counter = 0;
        dialog = GameObject.Find("Text").GetComponent<Text>();

        activated = true;

        chop.GetComponent<Image>().enabled = false;
        baba.GetComponent<Image>().enabled = true;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            canvas.GetComponent<Canvas>().enabled = true;
            counter = 1;
            //activated = true;
        }

        if (activated && Input.GetKeyDown(KeyCode.Q))
        {
            counter++;
           
        }

        if (counter == 0)
        {
            chop.GetComponent<Image>().enabled = true;
            baba.GetComponent<Image>().enabled = false;
            dialog.text = "TO KONIEC! PRZESTAŃ!";
        }
        else
        if (counter == 1)
        {
            chop.GetComponent<Image>().enabled = false;
            baba.GetComponent<Image>().enabled = true;
            dialog.text = "TO NIE JEST KONIEC, TO NAWET NIE JEST POCZĄTEK KOŃCA, TO DOPIERO KONIEC POCZĄTKU!";
        }
       else
        if (counter == 2)
        {
            canvas.GetComponent<Canvas>().enabled = false;
            //Destroy(gameObject.FindWithTag("plague"));
            Destroy(plague);
            cdnText.SetActive(true);
            levelTransition.FadeToLevel("MainMenu");

        }
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            enter = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canvas.GetComponent<Canvas>().enabled = false;
            enter = false;
            counter = 0;
        }
    }
}
