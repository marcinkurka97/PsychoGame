using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteConteiner : MonoBehaviour
{
    public Sprite[] pLegs, pUnarmedWalk, pPunch, pBaseballWalk, pBaseballAttack;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public Sprite[] getPlayerLegs()
    {
        return pLegs;
    }
    public Sprite[] getPlayerUnarmedWalk()
    {
        return pUnarmedWalk;
    }
    public Sprite[] getPlayerPunch()
    {
        return pPunch;
    }
    public Sprite[] getWeapon(string weapon)
    {
        switch (weapon)
        {
            case "Baseball":
                return pBaseballAttack;
                break;
            default:
                return getPlayerPunch();
                break;
        }
    }
    public Sprite[] getWeaponWalk(string weapon)
    {
        switch (weapon)
        {
            case "Baseball":
                return pBaseballWalk;
                break;
            default:
                return getPlayerUnarmedWalk();
                break;
        }
    }
}
