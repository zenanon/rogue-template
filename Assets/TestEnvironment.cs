using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using RogueTemplate;
using UnityEngine;
using UnityEngine.WSA;

/**
 * This class only exists as a temporary way to set up a test environment for the framework until all the necessary
 * components are in place to generate things the 'right way'.
 *
 * TODO: Remove this class when dungeon generation, actor population, and input are available.
 */
public class TestEnvironment : MonoBehaviour
{
	public RLTileRenderer TileRenderer;
	public RLTileType floor;
	public RLTileType wall;

	public RLActorController ActorPrefab;
	public RLSkill move;
	private RLBaseTile[,] _tiles;
	private SimpleActor _actor;

	public DungeonGenerator DungeonGenerator;
	
	public CinemachineVirtualCamera virtualCam;
	
	public RLEffectRenderer effectRenderer;

	public bool CanMove;
	
	// Use this for initialization
	void Start ()
	{
		DungeonFloor floor = DungeonGenerator.CreateFloor(new Dungeon());
		RLBaseTile start = null;
		foreach (RLBaseTile t in floor.Tiles)
		{
			if (t != null)
			{
				if (start == null)
				{
					start = t;
				}
				TileRenderer.BindTile(t);
			}
		}
		_actor = new SimpleActor {BasicMoveSkill = move};
		start.SetActor(_actor);
		RLActorController actorController = Instantiate(ActorPrefab, transform);
		actorController.effectRenderer = effectRenderer;
		actorController.BindActor(_actor);
		virtualCam.Follow = actorController.transform;
	}

	private void Update()
	{
		if (!CanMove)
		{
			return;
		}
		float horiz = Input.GetAxis("Horizontal");
		float vert = Input.GetAxis("Vertical");

		const float tolerance = 0.0001f;
		RLBaseTile targetTile = null;
		int x = _actor.GetTile().GetDisplayPosition().x;
		int y = _actor.GetTile().GetDisplayPosition().y;
		if (Math.Abs(horiz) > tolerance)
		{
			targetTile = _tiles[(int) (x + Mathf.Sign(horiz)), y];
		} else if (Math.Abs(vert) > tolerance)
		{
			targetTile = _tiles[x, (int) (y + Mathf.Sign(vert))];
		}

		if (targetTile != null)
		{
			_actor.TryBasicMoveToTile(targetTile);
			CanMove = false;
			StartCoroutine(ReenableInput());
		}
	}

	private IEnumerator ReenableInput()
	{
		yield return new WaitForSeconds(.3f);
		CanMove = true;
	}
}
