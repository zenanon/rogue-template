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
	private SimpleActor _actor;

	public StatBlockDisplay StatBlockDisplay;

	public DungeonGenerator DungeonGenerator;
	
	public CinemachineVirtualCamera virtualCam;
	
	public RLEffectRenderer effectRenderer;

	public StatBlock baseStats;

	public bool CanMove;
	private DungeonFloor dungeonFloor;

	// Use this for initialization
	void Start ()
	{
		dungeonFloor = DungeonGenerator.CreateFloor(64, 64, new Dungeon());
		RLBaseTile start = null;
		foreach (RLBaseTile t in dungeonFloor.Tiles)
		{
			if (t != null)
			{
				if (start == null && !t.GetTileType().BlocksMovement)
				{
					start = t;
				}
				TileRenderer.BindTile(t);
			}
		}
		_actor = new SimpleActor(baseStats) {
			BasicMoveSkill = move,
			fieldOfView = new BresenhamFOV(),
			OnVisibilityChanged = (tile, visible) =>
			{
				if (visible)
				{
					tile.SetCurrentlyVisibleToPlayer(true);
					tile.SetEverSeenByPlayer(true);
				}
				else
				{
					tile.SetCurrentlyVisibleToPlayer(false);
				}
			}};
		StatBlockDisplay.BindStatBlock(_actor.GetStats());
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
			targetTile = dungeonFloor.Tiles[(int) (x + Mathf.Sign(horiz)), y];
		} else if (Math.Abs(vert) > tolerance)
		{
			targetTile = dungeonFloor.Tiles[x, (int) (y + Mathf.Sign(vert))];
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
