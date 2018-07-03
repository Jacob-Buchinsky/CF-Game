using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new gear", menuName = "gear")]
public class Gear : ScriptableObject
{

    // Use this for initialization
    public new string name;
    public string description;

    public Sprite artwork;

    public int Armor;
    public int Mobility;
    public int Health;

    public void Print()
    {
        Debug.Log(name + ": " + description + " The Gear has " + Armor + " Armor and " + Mobility + " Mobility, and " + Health + " bonus health");
    }
}
