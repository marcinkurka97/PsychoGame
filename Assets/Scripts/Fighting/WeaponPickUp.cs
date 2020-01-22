using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    public string name;
    public float fireRate;
    WeaponAttack weaponAttack;
    public bool gun;

    void Start()
    {
        weaponAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponAttack>();
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player" && Input.GetMouseButtonDown(1))
        {
            if(weaponAttack.getCur() != null)
            {
                weaponAttack.dropWeapon();
            }
            weaponAttack.setWeapon(this.gameObject, name, fireRate, gun);
            this.gameObject.SetActive(false);
        }
    }
}
