using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegDir : MonoBehaviour
{
    Vector3 rot;
    PlayerMovement player;
    public Animator animator;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();;
        rot = new Vector3(0, 0, 0);
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            rot = new Vector3(0, 0, 0);
            transform.eulerAngles = rot;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rot = new Vector3(0, 0, 90);
            transform.eulerAngles = rot;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rot = new Vector3(0, 0, 270);
            transform.eulerAngles = rot;
        }

        animator.SetFloat("Speed", Mathf.Abs(player.movement.magnitude));
        if(!player.reachedCutSceneDestination) {
            animator.SetFloat("Speed", Mathf.Abs(player.direction.magnitude));
        }
    }
}
