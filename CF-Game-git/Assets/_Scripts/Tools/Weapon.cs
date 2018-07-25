using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new weapon", menuName = "weapons")]
public class Weapon : ScriptableObject {

    // Use this for initialization
    public new string name;
    public string description;

    public Sprite artwork;

    public int damage;
    public int accuracy;
    public int range;

    public void Print() {
        Debug.Log(name + ": " + description + " The Weapon has " + accuracy + " accuracy and " + range + " range");
    }
}
