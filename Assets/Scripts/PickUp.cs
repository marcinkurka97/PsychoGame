using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public GameObject item;
    public GameObject player;
    bool enter;
    bool pickedUp;

    // Start is called before the first frame update
    void Start()
    {
        item = GameObject.FindGameObjectWithTag("item");
        player = GameObject.FindGameObjectWithTag("Player");
        enter = false;
        pickedUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(enter == true && Input.GetMouseButtonDown(1) && pickedUp == false)
        {
            item.transform.parent = player.transform;
            pickedUp = true;
        }else if(pickedUp == true && Input.GetMouseButtonDown(1))
        {
            item.transform.parent = null;
            pickedUp = false;
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

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("triggered");

        if (other.tag == "Player")
        {

            enter = false;
            //pickedUp = false;
            // Debug.Log("clicked");
        }
    }

}
