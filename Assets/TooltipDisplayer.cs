using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipDisplayer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public Item.itemType slotType;

    public void OnPointerEnter(PointerEventData eventData)
    {
        GameObject.Find("Canvas").GetComponent<TooltipController>().displayTooltip();
        updateTooltipInformation();
    }

    public void updateTooltipInformation()
    {
        if (slotType == Item.itemType.WEAPON)
        {
            GameObject.Find("tooltipItemName").GetComponent<TextMeshProUGUI>().text = GameObject.Find("Player").GetComponent<PlayerEquipment>().getEquippedWeapon().name + 
                "(" + GameObject.Find("Player").GetComponent<PlayerEquipment>().getEquippedWeapon().rarityofItem + ")";
            GameObject.Find("tooltipItemDamage").GetComponent<TextMeshProUGUI>().text = "Damage: " + GameObject.Find("Player").GetComponent<PlayerEquipment>().getEquippedWeapon().weaponDamage;
            GameObject.Find("tooltipItemDescription").GetComponent<TextMeshProUGUI>().text = GameObject.Find("Player").GetComponent<PlayerEquipment>().getEquippedWeapon().itemDescription;
            setItemRarityColor(GameObject.Find("Player").GetComponent<PlayerEquipment>().getEquippedWeapon());
        } else if (slotType == Item.itemType.ARMOR)
        {
            GameObject.Find("tooltipItemName").GetComponent<TextMeshProUGUI>().text = GameObject.Find("Player").GetComponent<PlayerEquipment>().getEquippedArmor().name +
                "(" + GameObject.Find("Player").GetComponent<PlayerEquipment>().getEquippedArmor().rarityofItem +  ")";
            GameObject.Find("tooltipItemDamage").GetComponent<TextMeshProUGUI>().text = "Defense: " + GameObject.Find("Player").GetComponent<PlayerEquipment>().getEquippedArmor().armorDefense;
            GameObject.Find("tooltipItemDescription").GetComponent<TextMeshProUGUI>().text = GameObject.Find("Player").GetComponent<PlayerEquipment>().getEquippedArmor().itemDescription;
            setItemRarityColor(GameObject.Find("Player").GetComponent<PlayerEquipment>().getEquippedArmor());
        }

        
    }

    private void setItemRarityColor(Item item)
    {
        if (item.rarityofItem == Item.itemRarity.COMMON)
        {
            GameObject.Find("tooltipItemName").GetComponent<TextMeshProUGUI>().color = new Color32(100, 255, 0, 255);
        } else if (item.rarityofItem == Item.itemRarity.RARE)
        {
            GameObject.Find("tooltipItemName").GetComponent<TextMeshProUGUI>().color = new Color32(0, 185, 255, 255);
        } else
        {
            GameObject.Find("tooltipItemName").GetComponent<TextMeshProUGUI>().color = new Color32(195, 115, 255, 255);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GameObject.Find("Canvas").GetComponent<TooltipController>().hideTooltip();
    }
}
