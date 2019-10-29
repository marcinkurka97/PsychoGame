using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public float speed = 400f;
    public float NextWaypointDistance = 1f;
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    Seeker seeker;
    Rigidbody2D rb;

    private bool isFollowing = false;
    public Animator animator;

    private int randomSpot;
    public Transform[] moveSpots;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, .5f);
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    void Update() {
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.magnitude));

        if(!isFollowing) {
            Vector3 directionToPoint = path.vectorPath[currentWaypoint] - transform.position;
            float angleToPoint = Mathf.Atan2(directionToPoint.y, directionToPoint.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angleToPoint;
        }
    }

    public void Killed() {
        Destroy(gameObject);
    }

    void UpdatePath() {
        if(seeker.IsDone()) {
            if(!isFollowing) {
                seeker.StartPath(rb.position, moveSpots[randomSpot].position, OnPathComplete);
            } else {
                seeker.StartPath(rb.position, target.position, OnPathComplete);
            }
        }
    }

    void OnPathComplete(Path p) {
        if(!p.error) {
            path = p;
            currentWaypoint = 0;
        }
    }

    void FixedUpdate()
    {
        if(path == null) {
            return;
        }

        if(currentWaypoint >= path.vectorPath.Count) {
            randomSpot = Random.Range(0, moveSpots.Length);
            reachedEndOfPath = true;
            return;
        } else {
            reachedEndOfPath = false;
        }


        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        // transform.Translate(direction * speed * Time.deltaTime);
        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if(distance < NextWaypointDistance) {
            currentWaypoint++;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag == "Player") {
            isFollowing = true;
            speed = 1200f;
            Vector3 direction = target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        isFollowing = false;
        speed = 400f;
    }
}
