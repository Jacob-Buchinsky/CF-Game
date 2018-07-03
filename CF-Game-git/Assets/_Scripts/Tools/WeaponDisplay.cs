using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDisplay : MonoBehaviour {
    public Weapon weapon;
	// Use this for initialization
	void Start () {
        weapon.Print();
	}
	
}
