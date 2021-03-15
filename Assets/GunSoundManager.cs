using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSoundManager : MonoBehaviour
{

    public GameObject Player;
    PlayerEquipment playerEquipment;
    AudioClip weaponSound;

    // Start is called before the first frame update
    void Start()
    {
        playerEquipment = Player.GetComponent<PlayerEquipment>();
        ChangeWeaponSound();
    }

    public void ChangeWeaponSound()
    {
        weaponSound = playerEquipment.getEquippedWeapon().weaponSound;
        GetComponent<AudioSource>().clip = weaponSound;
    }
}
