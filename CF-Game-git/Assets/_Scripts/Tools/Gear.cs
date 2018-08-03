using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new gear", menuName = "gear")]
public class Gear : Item
{

    // Use this for initialization
    public EquipmentSlot equipSlot;

    public new string name;
    public string description;

    public Sprite artwork;

    public int Armor;
    public int Shields;
    public int Movement;
    public int Health;
    public int CostInStore;
    public int Ammo;
    public int Power;
    public int Energy;
    public int Range;

    public override void Use()
    {
        base.Use();
        Debug.Log("Attempting Ovveride of Use()");
        EquipmentManager.instance.Equip(this);

        // RemoveFromInventory();
    }

    public void Print()
    {
        Debug.Log(name + ": " + description + " The Gear has " + Armor + " Armor and " + Movement + " Mobility, and " + Health + " bonus health");
    }
}
public enum EquipmentSlot { Chassis, PowerSource, Legs, Weapon, Consumable}
