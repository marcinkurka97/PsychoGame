using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    public string name;
    public float fireRate;
    WeaponAttack wa;
    public bool gun;
    void Start()
    {
        wa = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponAttack>();
    }

    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        Debug.Log("Collision");
        if(coll.gameObject.tag == "Player" && Input.GetMouseButtonDown(1))
        {
            Debug.Log("Player picked up: " + name);
            if(wa.getCur() != null)
            {
                wa.dropWeapon();
            }
            wa.setWeapon(this.gameObject, name, fireRate, gun);
            this.gameObject.SetActive(false);
        }
    }
}
