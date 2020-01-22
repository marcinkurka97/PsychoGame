using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{

    public GameObject player;
    public GameObject canvas;
    public GameObject baba;
    public GameObject chop; 
    bool enter = false;
    bool activated;
    int counter;

    Text dialog;


    void Start()
    {
        enter = false;
        // canvas.GetComponent<Canvas>().enabled = false;
        counter = 0;
        dialog = GameObject.Find("Text").GetComponent<Text>();

        activated = false;

        chop.GetComponent<Image>().enabled = false;
        baba.GetComponent<Image>().enabled = true;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            canvas.GetComponent<Canvas>().enabled = true;
            counter = 1;
            activated = true;
        }

        if (activated && Input.GetKeyDown(KeyCode.Q))
        {
            counter++;
        }

        if (counter == 1)
        {
            chop.GetComponent<Image>().enabled = false;
            baba.GetComponent<Image>().enabled = true;
            dialog.text = "JAK TO JEST BYĆ SKRYBĄ?";
        }
        else
        if (counter == 2)
        {
            baba.GetComponent<Image>().enabled = false;
            chop.GetComponent<Image>().enabled = true;

            dialog.text = "A NO TO NIE MA TAK...";
        }
        else
        if (counter == 3)
        {
            dialog.text = "...ŻE DOBRZE CZY NIE DOBRZE";
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
