﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code adapted from Game Programming Academy's Tactics Movement Tutorial

public class TacticsMove : MonoBehaviour {
	List<Tile> selectableTiles = new List<Tile>();
	GameObject[] tiles;

	Stack<Tile> path = new Stack<Tile>();
	Tile currentTile;

	public bool moving = false;
	public int move = 5;
	public float jumpHeight = 2;
	public float movespeed = 2;

	Vector3 velocity = new Vector3();
	Vector3 heading = new Vector3();

	float halfHeight = 0;

	protected void init(){
		tiles = GameObject.FindGameObjectsWithTag ("Tile");

		halfHeight = GetComponent<Collider> ().bounds.extents.y;
	}

	public void GetCurrentTile()
	{
		currentTile = GetTargetTile(gameObject);
		currentTile.current = true;
	}

	public Tile GetTargetTile(GameObject target)
	{
		RaycastHit hit;
		Tile tile = null;

		if (Physics.Raycast (target.transform.position, -Vector3.up, out hit, 1))
		{
			tile = hit.collider.GetComponent<Tile>();
		}
		return tile;
	}

	public void ComputeAdjacencyLists(float jumpHeight, Tile target)
	{
		foreach (GameObject tile in tiles)
		{
			Tile t = tile.GetComponent<Tile> ();
			t.FindNeighbors (jumpHeight, target);
		}
	}

	public void FindSelectableTiles()
	{
		ComputeAdjacencyLists (jumpHeight, null);
		GetCurrentTile ();

		Queue<Tile> process = new Queue<Tile> ();
		process.Enqueue (currentTile);
		currentTile.visited = true;
		//currentTile.parent

		while (process.Count > 0)
		{
			Tile t = process.Dequeue ();
			selectableTiles.Add (t);
			t.selectable = true;

			if (t.distance < move)
			{
				foreach (Tile tile in t.adjacencyList) {
					if (!tile.visited) {
						tile.parent = t;
						tile.visited = true;
						tile.distance = 1 + t.distance;
						process.Enqueue (tile);
					}
				}
			}
		}
 	}

	public void MoveToTile(Tile tile)
	{
		path.Clear ();
		tile.target = true;
		moving = true;

		Tile next = tile;
		while (next != null)
		{
			path.Push (next);
			next = next.parent;
		}
	}
}
