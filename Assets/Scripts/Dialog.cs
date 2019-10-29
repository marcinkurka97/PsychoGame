using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{

    public GameObject player;
    public GameObject canvas;
    bool enter;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        canvas = GameObject.FindGameObjectWithTag("canvas");
        enter = false;

        canvas.GetComponent<Canvas>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(enter = true && Input.GetKeyDown(KeyCode.E))
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
        }
    }
}
