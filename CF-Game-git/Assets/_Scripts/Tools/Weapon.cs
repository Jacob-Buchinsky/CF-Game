using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new weapon", menuName = "weapons")]
public class Weapon : Item {

    // Use this for initialization
    public new string name;
    public string description;

    public Sprite artwork;

    public int Power;
    public int Accuracy;
    public int Range;
    public int Movement;
    public int Health;
    public int CostInStore;
    public int Ammo;

    public void Print() {
        Debug.Log(name + ": " + description + " The Weapon has " + Accuracy + " accuracy and " + Range + " range");
    }
}
