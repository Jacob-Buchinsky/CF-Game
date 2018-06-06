﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code adapted from Game Programming Academy's Tactics Movement Tutorial

public class PlayerMove : TacticsMove {

	// Use this for initialization
	void Start () {
		init ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!moving) 
		{
			FindSelectableTiles ();
			CheckMouse ();
		}
		else
		{
		}
	}
	void CheckMouse()
	{
		if (Input.GetMouseButtonUp (0))
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			RaycastHit hit;
			if(Physics.Raycast(ray, out hit))
			{
				if (hit.collider.tag == "Tile")
				{
					Tile t = hit.collider.GetComponent<Tile> ();

					if (t.selectable)
					{
						MoveToTile (t);
					}
				}
			}
		}
	}
}