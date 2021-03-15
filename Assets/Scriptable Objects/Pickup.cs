using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pickup", menuName = "New Item/Pickup")]
public class Pickup : Item
{
    public enum BoostType { HP, ENERGY, AMMO};
    public BoostType pickupBoostType;
    public int boostAmount;

    
    
}
