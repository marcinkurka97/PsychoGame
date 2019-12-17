using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System.Linq;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public float speed = 400f;
    public float NextWaypointDistance = 1f;
    public Transform[] moveSpots;
    public Animator animator;

    private Path path;
    private int currentWaypoint;
    private bool reachedEndOfPath;
    private Seeker seeker;
    private Rigidbody2D rb;

    private bool isFollowing;

    private int randomSpot;

    public GameObject ghostBody;
    public GameObject humanoidBody;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, .5f);
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.magnitude));
    }

    public void Killed()
    {
        if(transform.parent.tag == "Enemy") {
            Instantiate(ghostBody, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if(transform.parent.tag == "EnemyHumanoid") {
            Instantiate(humanoidBody, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            if (!isFollowing)
            {
                seeker.StartPath(rb.position, moveSpots[randomSpot].position, OnPathComplete);
            }
            else
            {
                seeker.StartPath(rb.position, target.position, OnPathComplete);
            }
        }

        UpdateMoveDirection();
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void FixedUpdate()
    {
        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            randomSpot = Random.Range(0, moveSpots.Length);
            reachedEndOfPath = true;
            return;
        }

        reachedEndOfPath = false;

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < NextWaypointDistance)
        {
            currentWaypoint++;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "PlayerCollider" && !IsItemBetween(target, transform, "item"))
        {
            animator.SetBool("IsAttacking", true);
            isFollowing = true;
            speed = 1200f;
            Vector3 direction = target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        animator.SetBool("IsAttacking", false);
        isFollowing = false;
        speed = 400f;
    }

    private void UpdateMoveDirection()
    {
        if (!isFollowing && path != null && path.vectorPath.Count > currentWaypoint)
        {
            Vector3 directionToPoint = path.vectorPath[currentWaypoint] - transform.position;
            float angleToPoint = Mathf.Atan2(directionToPoint.y, directionToPoint.x) * Mathf.Rad2Deg - 90f;

            if (System.Math.Abs(rb.rotation - angleToPoint) > float.Epsilon)
                rb.rotation = angleToPoint;
        }
    }

    private bool IsItemBetween(Transform item1, Transform item2, string itemTag)
    {
        var raycastHits = Physics2D.LinecastAll(item1.position, item2.position);

        return raycastHits.Any(x => x.collider.tag.Equals(itemTag));
    }
}
