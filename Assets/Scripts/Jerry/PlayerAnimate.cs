using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimate : MonoBehaviour
{
    Sprite[] walking, attacking, legSpr;
    int counter = 0, legCount = 0;
    PlayerMovement1 pm;
    float timer = 0.05f, legTimer = 0.05f;
    public SpriteRenderer torso, legs;
    SpriteConteiner sc;

    bool attackingB = false;
    void Start()
    {
        pm = this.GetComponent<PlayerMovement1>();
        sc = GameObject.FindGameObjectWithTag("GameController").GetComponent<SpriteConteiner>();
        walking = sc.getPlayerUnarmedWalk();
        attacking = sc.getPlayerPunch();
        legSpr = sc.getPlayerLegs();
    }

    void Update()
    {
        animateLegs();
        if(attackingB == false)
        {
            animateTorso();
        } else
        {
            animateAttack();
        }
        
    }

    void animateTorso()
    {
        if(pm.moving == true)
        {
            torso.sprite = walking[counter];
            timer -= Time.deltaTime;
            if(timer<=0)
            {
                if(counter < walking.Length - 1)
                {
                    counter++;
                } else
                {
                    counter = 0;
                }
                timer = 0.1f;
            }
        }
    }

    void animateAttack()
    {
        torso.sprite = attacking[counter];

        timer -= Time.deltaTime;
        if(timer<=0)
        {
            if(counter < attacking.Length - 1)
            {
                counter++;
            } else
            {
                if(attackingB == true)
                {
                    attackingB = false;
                }
                counter = 0;
            }
            timer = 0.1f;
        }
    }

    void animateLegs()
    {
        if (pm.moving == true)
        {
            legs.sprite = legSpr[legCount];
            legTimer -= Time.deltaTime;
            if (legTimer <= 0)
            {
                if(legCount < legSpr.Length - 1)
                {
                    legCount++;
                } else
                {
                    legCount = 0;
                }
                legTimer = 0.1f;
            }
        }
    }

    public void attack()
    {
        attackingB = true;
    }

    public void resetCounter()
    {
        counter = 0;
    }

    public bool getAttack()
    {
        return attackingB;
    }

    public void setNewTorso(Sprite[] walk, Sprite[] attack)
    {
        counter = 0;
        attacking = attack;
        walking = walk;
    }
}
