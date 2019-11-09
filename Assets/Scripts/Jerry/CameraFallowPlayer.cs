using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFallowPlayer : MonoBehaviour
{
    GameObject player;
    PlayerMovement1 pn;
    bool fallowPlayer = true;
    Vector3 mousePos;
    Camera cam;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pn = player.GetComponent<PlayerMovement1>();
        cam = Camera.main;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            fallowPlayer = false;
            pn.SetMoving(false);
        } 
        else
        {
            fallowPlayer = true;
        }

        if (fallowPlayer == true)
        {
            camFallowPlayer();
        } 
        else
        {
            lookAhead();
        }
    }

    public void setFollowPlayer(bool val)
    {
        fallowPlayer = val;
    }

    void camFallowPlayer()
    {
        Vector3 newPos = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);
        this.transform.position = newPos;
    }

    void lookAhead()
    {
        Vector3 camPos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
        camPos.z = -10;
        Vector3 dir = camPos - this.transform.position;
        if(player.GetComponent<SpriteRenderer>().isVisible == true)
        {
            transform.Translate(dir * 2 * Time.deltaTime);
        }
    }
}
