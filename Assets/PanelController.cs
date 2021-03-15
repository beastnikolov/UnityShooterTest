using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    public GameObject playerGameObject;
    public GameObject weaponSlot;
    public GameObject armorSlot;
    public GameObject equippedArmorText;
    public GameObject equippedWeaponText;
    public GameObject ammoText;
    public GameObject previewPanel;


    // Start is called before the first frame update
    void Start()
    {
        updateEquipmentUI();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateEquipmentUI()
    {
        equippedArmorText.GetComponent<TextMeshProUGUI>().text = "Weapon: " + playerGameObject.GetComponent<PlayerEquipment>().getEquippedArmor().itemName + " (" +
            playerGameObject.GetComponent<PlayerEquipment>().getEquippedArmor().armorDefense + " DEF)";
        equippedWeaponText.GetComponent<TextMeshProUGUI>().text = "Weapon: " + playerGameObject.GetComponent<PlayerEquipment>().getEquippedWeapon().itemName + " (" +
            playerGameObject.GetComponent<PlayerEquipment>().getEquippedWeapon().weaponDamage + " DMG)"; ;
        ammoText.GetComponent<TextMeshProUGUI>().text = "Ammo: " + playerGameObject.GetComponent<Shooting>().Ammunition;
        previewPanel.GetComponentsInChildren<Image>()[1].sprite = playerGameObject.GetComponent<PlayerEquipment>().getEquippedArmor().playerLookSprite;
        weaponSlot.GetComponent<Image>().sprite = playerGameObject.GetComponent<PlayerEquipment>().getEquippedWeapon().itemSprite;
        armorSlot.GetComponent<Image>().sprite = playerGameObject.GetComponent<PlayerEquipment>().getEquippedArmor().itemSprite;
    }
}
