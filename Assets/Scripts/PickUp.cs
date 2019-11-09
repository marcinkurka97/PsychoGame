using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public GameObject item;
    public GameObject player;
    bool enter;

    // Start is called before the first frame update
    void Start()
    {
        item = GameObject.FindGameObjectWithTag("item");
        player = GameObject.FindGameObjectWithTag("Player");
        enter = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(enter == true && Input.GetMouseButtonDown(1))
        {
            item.GetComponent<SpriteRenderer>().enabled = false;
            Debug.Log("dziala");
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("triggered");

        if (other.tag == "Player")
        {
            
            enter = true;
           // Debug.Log("clicked");
        }
    }
}
