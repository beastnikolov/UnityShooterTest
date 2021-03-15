using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    public Item weaponSlot;
    public Item armorSlot;
    public Empty emptySlot;
    public GameObject equipmentUI;
    bool equipmentOpened = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            if (equipmentOpened)
            {
                closeEquipment();
            } else
            {
                openEquipment();
            }
        }
    }

    public void equipWeapon(Weapon weapon)
    {
        weaponSlot = weapon;
    }

    public void equipArmor(Armor armor) 
    {
        armorSlot = armor;
    }



    public Weapon getEquippedWeapon()
    {
        var equippedWeapon = weaponSlot as Weapon;
        if (equippedWeapon)
        {
            return equippedWeapon;
        }
        return null;
    }

    public Armor getEquippedArmor()
    {
        var equippedArmor = armorSlot as Armor;
        if (equippedArmor)
        {
            return equippedArmor;
        }
        return null;
    }

    public void openEquipment()
    {
        equipmentOpened = true;
        Time.timeScale = 0;
        equipmentUI.SetActive(true);
        equipmentUI.GetComponent<PanelController>().updateEquipmentUI();
    }

    public void closeEquipment()
    {
        Time.timeScale = 1;
        equipmentOpened = false;
        equipmentUI.SetActive(false);
        equipmentUI.GetComponent<PanelController>().updateEquipmentUI();
        GameObject.Find("Canvas").GetComponent<TooltipController>().hideTooltip();
    }
}
