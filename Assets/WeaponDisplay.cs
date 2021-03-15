using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDisplay : MonoBehaviour
{
    public Weapon weaponItem;
    public Image weaponImage;
    public TextMeshProUGUI weaponName;
    public TextMeshProUGUI weaponDamage;
    public TextMeshProUGUI weaponDescription;

    // Start is called before the first frame update
    void Start()
    {
        weaponImage.sprite = weaponItem.itemSprite;
        weaponImage.transform.localScale = new Vector2(weaponItem.itemSpriteScale, weaponItem.itemSpriteScale);
        weaponName.text = weaponItem.itemName;
        weaponDamage.text = "Damage: " + weaponItem.weaponDamage.ToString();
        weaponDescription.text = weaponItem.itemDescription;
    }

}
