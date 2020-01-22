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
    bool activated = false;
    int counter = 0;

    Text dialog;
    string[] dialogues = {"JAK TO JEST BYĆ SKRYBĄ?", "A NO TO NIE MA TAK...", "...ŻE DOBRZE CZY NIE DOBRZE"};

    void Start()
    {
        dialog = GameObject.Find("Text").GetComponent<Text>();
        chop.GetComponent<Image>().enabled = false;
        baba.GetComponent<Image>().enabled = true;
    }

    void Update()
    {
        if (enter && Input.GetKeyDown(KeyCode.E))
        {
            activated = true;
            canvas.GetComponent<Canvas>().enabled = true;
            dialog.text = dialogues[counter];
        }

        if (activated && Input.GetKeyDown(KeyCode.Q))
        {
            if(counter < dialogues.Length - 1) {
                counter++;
            }
            dialog.text = dialogues[counter];
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
            activated = false;
            counter = 0;
        }
    }
}
