using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<Item> playerInventoryList = new List<Item>();
    public InventoryDisplay inventoryDisplay;
    public GameObject inventoryWindow;
    public int maxSlots;
    int takenSpots;
    int availableSpots;
    PlayerEquipment playerEquipment;
    bool inventoryOpened = false;


    private void Start()
    {
        
       // inventoryDebug();
    }

    private void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            if (inventoryOpened)
            {
                closeInventory();
            }
            else
            {
                openInventory();
            }
        }
    }

    public void openInventory()
    {
        inventoryOpened = true;
        Time.timeScale = 0;
        inventoryWindow.SetActive(true);
        inventoryDisplay.instantiateItems(playerInventoryList);
    }

    public void closeInventory()
    {
        Time.timeScale = 1;
        inventoryOpened = false;
        inventoryWindow.SetActive(false);
        inventoryDisplay.instantiateItems(playerInventoryList);
    }

    private void Awake()
    {
        playerEquipment = GetComponent<PlayerEquipment>();
        takenSpots = playerInventoryList.Count;
        availableSpots = getAvailableSpots();
        inventorySetup();
    }

    public void inventorySetup()
    {
        playerInventoryList[0] = playerEquipment.getEquippedWeapon();
        playerInventoryList[1] = playerEquipment.getEquippedArmor();
    }

    public void inventoryDebug()
    {
        Debug.Log("Inventory capacity: " + maxSlots + "| Taken spots: " + takenSpots + " | Available spots: " + availableSpots + " Current items in inventory: ");
        for (int i = 0; i < playerInventoryList.Count; i++)
        {
            Debug.Log("Item name: " + playerInventoryList[i].itemName + " Item count: " + playerInventoryList[i].itemCount);
        }
    }


    public int getAvailableSpots()
    {
        return maxSlots - takenSpots;
    }

    public void addItem(Item item) 
    {
        if (!(item.typeOfItem.Equals(Item.itemType.WEAPON)) && (!(item.typeOfItem.Equals(Item.itemType.ARMOR))) && (!(item.typeOfItem.Equals(Item.itemType.PICKUP))))
        {
            for (int i = 0; i < playerInventoryList.Count; i++)
            {
                if (item.Equals(playerInventoryList[i]))
                {
                    if (item.itemCount >= 1)
                    {
                        // There is more than 1 so 1 item count is increased
                        item.itemCount++;
                        Debug.Log("Item count increased");
                        return;
                    }
                }
            }
            /* There is is only 1 unit so it's added
            playerInventoryList.Add(item);
            Debug.Log("Other item added");
            return;
            */
        } else if ((item.typeOfItem.Equals(Item.itemType.PICKUP)))
            {
                Debug.Log("Item is a pickup, rejected");
                return;
            }
         else
        {
            if (getAvailableSpots() > 0)
            {
                if (doesItemExist(item))
                {
                    Debug.Log("Item not added, it already exists");
                    return;
                } else
                {
                    playerInventoryList.Add(item);
                    takenSpots++;
                    inventoryDisplay.instantiateItems(playerInventoryList);
                    Debug.Log("Equipment Item added");
                }
            } else
            {
                Debug.Log("Backpack is full, item not added!");
            }
            
        }
    }

    public bool doesItemExist(Item item) 
    {
        for (int i = 0; i < playerInventoryList.Count; i++)
        {
            if (item.Equals(playerInventoryList[i]))
            {
                Debug.Log("This item already exists!");
                return true;
            }
        }
        Debug.Log("This item does not exist in inventory!");
        return false;
    }

    public void deleteItem(Item item)
    {
        for (int i = 0; i < playerInventoryList.Count; i++)
        {
            if (item.Equals(playerInventoryList[i]))
            {
                if (item.typeOfItem != Item.itemType.ARMOR || item.typeOfItem != Item.itemType.WEAPON)
                {
                    // It's a pickup / crafting material
                    if (item.itemCount > 1)
                    {
                        // There is more than 1 so 1 item count is removed
                        item.itemCount--;
                        inventoryDisplay.instantiateItems(playerInventoryList);
                        return;
                    } else
                    {
                        // There is is only 1 unit so it's deleted
                        playerInventoryList.Remove(playerInventoryList[i]);
                        inventoryDisplay.instantiateItems(playerInventoryList);
                        return;
                    }
                } else
                {
                    // The item type is an ARMOR/WEAPON
                    if (item.isItemDeletable)
                    {
                        // Not part of the basic items so it's removed
                        playerInventoryList.Remove(playerInventoryList[i]);
                        takenSpots -= 1;
                        Debug.Log("Deleted: " + item.itemName + " from inventory!");
                        return;
                    } else
                    {
                        // It's a basic item so it's not removed
                        Debug.Log("This item cannot be removed!");
                        return;
                    }
                }
            }
        }
        Debug.Log("Can't destroy an item that does not exist");
    }

    public bool equipItem(Item item)
    {
        var itemWeapon = item as Weapon;
        if (itemWeapon)
        {
            Debug.Log("Equipping " + itemWeapon.typeOfItem +  " | Name: " + itemWeapon.itemName);
            playerEquipment.equipWeapon(itemWeapon);
            GetComponent<Shooting>().onEquipUpdate();
            GameObject.Find("EquippedWeapon").GetComponent<EquippedWeaponManager>().updateEquippedWeapon();
            GetComponentInChildren<GunSoundManager>().ChangeWeaponSound();
            inventoryDisplay.instantiateItems(playerInventoryList);
            return true;
        }
        var itemArmor = item as Armor;
        if (itemArmor)
        {
            Debug.Log("Equipping " + itemArmor.typeOfItem + " | Name: " + itemArmor.itemName);
            playerEquipment.equipArmor(itemArmor);
            inventoryDisplay.instantiateItems(playerInventoryList);
            return true;
        }
        Debug.Log("This item is not a weapon/armor!");
        return false;
    }

    public List<Item> getInventoryItemList()
    {
        return playerInventoryList;
    }

}
