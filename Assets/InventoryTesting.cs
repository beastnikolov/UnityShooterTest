using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTesting : MonoBehaviour
{

    public Item item1;
    // Start is called before the first frame update
    void Start()
    {
        var rangedWeapon = item1 as Weapon;
        if (rangedWeapon)
        {
            Debug.Log("The item is a weapon and the damage is: " + rangedWeapon.weaponDamage);
        } else
        {
            Debug.Log("This item is NOT a weapon");
        }
    }


}
