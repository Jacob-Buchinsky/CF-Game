using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomPlayerFixes : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject varGameObject = GameObject.FindWithTag("Player");
        varGameObject.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
