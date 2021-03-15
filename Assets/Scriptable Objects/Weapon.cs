using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "New Item/Weapon")]
public class Weapon : Item
{
    public int weaponDamage;
    public float weaponForce;
    public float weaponDelay;
    public float weaponReloadTime;
    public int maxRoundsPerMag;
    public AudioClip weaponSound;
}
