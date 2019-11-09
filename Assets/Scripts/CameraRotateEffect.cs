using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateEffect : MonoBehaviour
{
    PlayerMovement1 pn;
    float mod = 0.02f;
    float zVal = 0.0f;
    void Start()
    {
        pn = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement1>();
    }

    void Update()
    {
        if(pn.moving == true)
        {
            Vector3 rot = new Vector3(0, 0, zVal);
            this.transform.eulerAngles = rot;

                zVal += mod;

            if(transform.eulerAngles.z >= 5.0f && transform.eulerAngles.z < 10.0f)
            {
                mod = -0.02f;
            }
            else if(transform.eulerAngles.z < 355.0f && transform.eulerAngles.z > 350.0f)
            {
                mod = 0.02f;
            }
        }
    }
}
