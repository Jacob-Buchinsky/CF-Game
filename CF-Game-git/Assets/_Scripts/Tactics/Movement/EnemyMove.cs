using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code adapted from Game Programming Academy's Tactics Movement Tutorial

public class EnemyMove : TacticsMove {
	GameObject target;

	// Use this for initialization
	void Start () 
	{
		init();
	}

	// Update is called once per frame
	void Update () 
	{
		RemoveSelectableTiles ();

		Debug.DrawRay(transform.position, transform.forward);

		if (!turn)
		{
			return;
		}

		if (!moving)
		{
			FindNearestTarget();
			CalculatePath();
			FindSelectableTiles();
			actualTargetTile.target = true;
		}
		else
		{
			Move();
		}
	}

	void CalculatePath()
	{
		Tile targetTile = GetTargetTile(target);
		FindPath(targetTile);
	}


	//I'm too lazy to do this now, this will only find the nearest target
	//later it will calculate unit class, weaknesses, and damage, etc.
	void FindNearestTarget()
	{
		GameObject[] targets = GameObject.FindGameObjectsWithTag("Player");

		GameObject nearest = null;
		float distance = Mathf.Infinity;

		foreach (GameObject obj in targets)
		{
			float d = Vector3.Distance(transform.position, obj.transform.position);

			if (d < distance)
			{
				distance = d;
				nearest = obj;
			}
		}

		target = nearest;
	}
}
