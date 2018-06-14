﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code adapted from Game Programming Academy's Tactics Movement Tutorial

public class TacticsMove : MonoBehaviour {

	public bool turn = false;

	List<Tile> selectableTiles = new List<Tile>();
	GameObject[] tiles;

	Stack<Tile> path = new Stack<Tile>();
	Tile currentTile;

	public bool moving = false;
	public int move = 5;
	public float jumpHeight = 2;
	public float movespeed = 2;
	public float jumpVelocity = 4.5f;

	Vector3 velocity = new Vector3();
	Vector3 heading = new Vector3();

	float halfHeight = 0;

	bool jumpingUp = false;
	bool fallingDown = false;
	bool movingEdge = false;

	Vector3 jumpTarget;

	protected void init(){
		tiles = GameObject.FindGameObjectsWithTag ("Tile");

		halfHeight = GetComponent<Collider> ().bounds.extents.y;

		TurnManager.AddUnit (this);
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

	public void Move()
	{
		if (path.Count > 0)
		{
			Tile t = path.Peek();
			Vector3 target = t.transform.position;

			//Calculate the unit's position on top of the target tile
			target.y += halfHeight + t.GetComponent<Collider>().bounds.extents.y;

			if (Vector3.Distance(transform.position, target) >= 0.05f)
			{
				bool jump = transform.position.y != target.y;

				if (jump)
				{
					Jump(target);
				}
				else
				{
					CalculateHeading(target);
					SetHorizontalVelocity();
				}

				//Locomotion
				transform.forward = heading;
				transform.position += velocity * Time.deltaTime;
			}
			else
			{
				//Tile center reached
				transform.position = target;
				path.Pop();
			}
		}
		else
		{
			RemoveSelectableTiles();
			moving = false;

			TurnManager.EndTurn ();
		}
	}

	protected void RemoveSelectableTiles()
	{
		if (currentTile != null)
		{
			currentTile.current = false;
			currentTile = null;
		}
		foreach (Tile tile in selectableTiles)
		{
			tile.Reset ();
		}
		selectableTiles.Clear ();
	}

	void CalculateHeading(Vector3 target)
	{
		heading = target - transform.position;
		heading.Normalize();
	}

	void SetHorizontalVelocity()
	{
		velocity = heading * movespeed;
	}

	void Jump(Vector3 target)
	{
		if (fallingDown)
		{
			FallDownward(target);
		}
		else if (jumpingUp)
		{
			JumpUpward(target);
		}
		else if (movingEdge)
		{
			MoveToEdge();
		}
		else
		{
			PrepareJump(target);
		}
	}

	void PrepareJump(Vector3 target)
	{
		float targetY = target.y;
		target.y = transform.position.y;

		CalculateHeading(target);

		if (transform.position.y > targetY)
		{
			fallingDown = false;
			jumpingUp = false;
			movingEdge = true;

			jumpTarget = transform.position + (target - transform.position) / 2.0f;
		}
		else
		{
			fallingDown = false;
			jumpingUp = true;
			movingEdge = false;

			velocity = heading * movespeed / 3.0f;

			float difference = targetY - transform.position.y;

			velocity.y = jumpVelocity * (0.5f + difference / 2.0f);
		}
	}

	void FallDownward(Vector3 target)
	{
		velocity += Physics.gravity * Time.deltaTime;

		if (transform.position.y <= target.y)
		{
			fallingDown = false;
			jumpingUp = false;
			movingEdge = false;

			Vector3 p = transform.position;
			p.y = target.y;
			transform.position = p;

			velocity = new Vector3();
		}
	}

	void JumpUpward(Vector3 target)
	{
		velocity += Physics.gravity * Time.deltaTime;

		if (transform.position.y > target.y)
		{
			jumpingUp = false;
			fallingDown = true;
		}
	}

	void MoveToEdge()
	{
		if (Vector3.Distance(transform.position, jumpTarget) >= 0.05f)
		{
			SetHorizontalVelocity();
		}
		else
		{
			movingEdge = false;
			fallingDown = true;

			velocity /= 5.0f;
			velocity.y = 1.5f;
		}
	}

	public void BeginTurn()
	{
		turn = true;
	}

	public void EndTurn()
	{
		turn = false;
	}
}
