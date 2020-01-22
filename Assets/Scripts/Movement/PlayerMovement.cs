using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Vector2 movement;
    public Vector2 direction;
    public float angle;

    Vector2 mousePos;
    public Camera cam;
    public Animator animator;
    public bool moving = false;
    public GameObject cutScenePoint;
    public bool reachedCutSceneDestination = true;

    // Update is called once per frame
    void Update(){
        if(reachedCutSceneDestination) {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            animator.SetFloat("Speed", Mathf.Abs(movement.magnitude));

            if(movement.magnitude > 0.01) {
                moving = true;
            } else {
                moving = false;
            }
        }
    }

    void FixedUpdate() {
        if(!reachedCutSceneDestination){
            MovePlayerToPoint();
        }

        if(reachedCutSceneDestination) {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
            Vector2 lookDir = mousePos - rb.position;

            angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "EnemyHumanoid") {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void MovePlayerToPoint() {
        direction = (cutScenePoint.transform.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * moveSpeed * Time.deltaTime);
        animator.SetFloat("Speed", Mathf.Abs(direction.magnitude));


        if(Vector2.Distance(cutScenePoint.transform.position, transform.position) < 1f) {
            reachedCutSceneDestination = true;
        }
    }
}
