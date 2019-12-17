using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttack : MonoBehaviour
{
    GameObject curWeapon;
    bool gun = false;
    float timer = 0.1f, timerReset = 0.1f;
    string weaponName = "";

    float weaponChange = 0.5f;
    bool changingWeapon = false;

    public Animator animator;


    // Mele attack
    bool enemyInMeleRange = false;
    GameObject enemyReference = null;
    public GameObject enemyDeathBlood;

    // Pistol shooting
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 10f;
    private float nextFire = 0;


    void Start()
    {
        nextFire = Time.time;
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            StartCoroutine(attack());
        }
        if(Input.GetMouseButtonDown(0))
        {
            // Continue attacking
        }
        if (Input.GetMouseButtonUp(0))
        {
            // Stop attacking
        }

        if(Input.GetMouseButtonDown(1) && changingWeapon==false)
        {
            dropWeapon();
        }

        if(changingWeapon==true)
        {
            weaponChange -= Time.deltaTime;
            if(weaponChange<=0)
            {
                changingWeapon = false;
            }
        }
    }

    public void setWeapon(GameObject cur, string name, float fireRate, bool gun)
    {
        changingWeapon = true;
        curWeapon = cur;
        weaponName = name;
        this.gun = gun;
        timerReset = fireRate;
        timer = timerReset;

        if(name == "Baseball") {
            animator.SetBool("Baseball", true);
        }

        if(name == "Pistol") {
            animator.SetBool("GunInHand", true);
        }
    }

    // Check if enemy is in mele range
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "EnemyDestroy") {
            enemyInMeleRange = true;
        }
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "EnemyHumanoid") {
            enemyReference = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "EnemyDestroy") {
            enemyInMeleRange = false;
            enemyReference = null;
        }
    }

    public IEnumerator attack()
    {
        if(gun) {
            if(Time.time > nextFire) {
                Shoot();
                nextFire = Time.time + timerReset;
            }
        }

        if(weaponName == "") {
            GetComponent<Animator>().SetBool("MeleAttack",true);
            yield return new WaitForSeconds(0.4f);
            GetComponent<Animator>().SetBool("MeleAttack",false);
        }

        if(weaponName == "Baseball") {
            GetComponent<Animator>().SetBool("BaseballAttack",true);
            yield return new WaitForSeconds(0.35f);
            GetComponent<Animator>().SetBool("BaseballAttack",false);
        }
    }

    void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    public GameObject getCur()
    {
        return curWeapon;
    }

    public void dropWeapon()
    {
        if(weaponName == "Baseball") {
            animator.SetBool("Baseball", false);
        }

        if(weaponName == "Pistol") {
            animator.SetBool("GunInHand", false);
        }

        weaponName = "";
        curWeapon.transform.position = this.transform.position;
        curWeapon.SetActive(true);
        setWeapon(null, "", 0.5f, false);
    }

    public void BaseballAttackEvent() {
        if(enemyInMeleRange && enemyReference != null) {
            GameObject effect = Instantiate(enemyDeathBlood, enemyReference.transform.position, Quaternion.identity);
            Destroy(effect, 1f);
            enemyReference.GetComponent<EnemyAI>().Killed();
        }
    }
}
