using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFallowPlayer : MonoBehaviour
{
    GameObject player;
    bool fallowPlayer = true;
    Vector3 mousePos;
    Camera cam;
    private float fraction = 0; 

    float distance;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cam = Camera.main;

        Vector3 newPos = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);
        this.transform.position = newPos;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift)) {
            fallowPlayer = false;
        } else {
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

    void camFallowPlayer() {
        if(transform.position.x != player.transform.position.x && transform.position.y != player.transform.position.y) {
            Vector3 start = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            Vector3 des = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);

            if (fraction < 1) {
                fraction += Time.deltaTime * 5f;
                this.transform.position = Vector3.Lerp(start, des, fraction);
            }

            this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);;
        } else {
            Vector3 newPos = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);
            this.transform.position = newPos;
        }
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
