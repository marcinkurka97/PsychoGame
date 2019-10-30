using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{

    public GameObject player;
    public GameObject canvas;
    bool enter = false;
    int counter;

    Text dialog;


    void Start()
    {
        enter = false;
        canvas.GetComponent<Canvas>().enabled = false;
        counter = 0;
        dialog = GameObject.Find("Text").GetComponent<Text>();
    }

    void Update()
    {
        if(enter == true && Input.GetKeyDown(KeyCode.E))
        {
            canvas.GetComponent<Canvas>().enabled = true;
            counter++;
        }

        if (Input.GetKeyDown(KeyCode.Q) &&  enter == true)
        {
            counter++;
            
            if (counter >= 2)
            {
                counter = 2;
            }
        }

        if(counter == 1)
        {
            dialog.text = "Ah, szkoda gadać";
        }
        if (counter == 2)
        {
            dialog.text = "Szkoda szczempić ryja";
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
