using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{

    GameObject playerObject;

    void Start()
    {
        playerObject = GameObject.Find("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    public int getWeaponDamage()
    {   
        int weaponDmg = playerObject.GetComponent<PlayerEquipment>().getEquippedWeapon().weaponDamage;
        return weaponDmg;
    }
}
