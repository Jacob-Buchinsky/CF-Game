using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearDisplay : MonoBehaviour
{
    public Gear gear;
    // Use this for initialization
    void Start()
    {
        gear.Print();
    }

}
