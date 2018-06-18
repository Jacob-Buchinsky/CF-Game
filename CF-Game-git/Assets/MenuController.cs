using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {
    public Transform Canvas;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (Canvas.gameObject.activeInHierarchy == false) {
                Canvas.gameObject.SetActive(true);
            }
            else Canvas.gameObject.SetActive(false);
        }
	}
}
