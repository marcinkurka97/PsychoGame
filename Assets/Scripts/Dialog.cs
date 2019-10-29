using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{

    public GameObject player;
    public GameObject canvas;
    bool enter = false;
    

    void Start()
    {
        enter = false;
        canvas.GetComponent<Canvas>().enabled = false;
    }

    void Update()
    {
        if(enter == true && Input.GetKeyDown(KeyCode.E))
        {
            canvas.GetComponent<Canvas>().enabled = true;
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
        }
    }
}
