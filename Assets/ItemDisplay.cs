using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    public Image itemSprite;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemStat;
    public Image equippedItemSprite;
    public GameObject equipButton;
    Item heldItem;



    // Start is called before the first frame update
    void Start()
    {
        var currentItem = heldItem as CraftingMaterial;
        if (currentItem)
        {
            equipButton.SetActive(false);
            Debug.Log("Disable button");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateItemEntry(Item item)
    {
        heldItem = item;
        itemSprite.sprite = item.itemSprite;
        itemName.text = item.itemName;
        setStat(item);
        if (item.Equals(GameObject.Find("Player").GetComponent<PlayerEquipment>().getEquippedWeapon()) || item.Equals(GameObject.Find("Player").GetComponent<PlayerEquipment>().getEquippedArmor()))
        {
            equippedItemSprite.enabled = true;
        } else
        {
            equippedItemSprite.enabled = false;
        }
    }

    public void setStat(Item item)
    {
        var weaponStat = item as Weapon;
        if (weaponStat)
        {
            itemStat.text = "DMG: " + weaponStat.weaponDamage;
            return;
        }
        var armorStat = item as Armor;
        if (armorStat)
        {
            itemStat.text = "DEF: " + armorStat.armorDefense;
            return;
        }
        // The item is not equipable so we display stack size
        itemStat.text = "x" + item.itemCount;
    }

    public void deleteItem()
    {
        if (heldItem != null)
        {
            GameObject.Find("Player").GetComponent<PlayerInventory>().deleteItem(heldItem);
        }
    }

    public void equipItem()
    {
        GameObject.Find("Player").GetComponent<PlayerInventory>().equipItem(heldItem);
    }
}
