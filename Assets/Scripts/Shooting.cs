using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 10f;
    public Animator animator;
    public float fireRate = 1f;
    private float nextFire = 0;

    private void Start() {
        nextFire = Time.time;
    }

    void Update()
    {
        if(Input.GetMouseButton(0)) {
            if(Time.time > nextFire) {
                Shoot();
                nextFire = Time.time + fireRate;
            }
        } else {
            animator.SetBool("IsShooting", false);
        }
    }

    void Shoot() {
        animator.SetBool("IsShooting", true);
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
