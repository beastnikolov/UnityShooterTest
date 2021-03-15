using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquippedWeaponManager : MonoBehaviour
{

    public GameObject player;
    Image weaponSprite;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Image>().sprite = player.GetComponent<PlayerEquipment>().getEquippedWeapon().itemSprite;
    }

    public void updateEquippedWeapon()
    {
        gameObject.GetComponent<Image>().sprite = player.GetComponent<PlayerEquipment>().getEquippedWeapon().itemSprite;
    }
}
