using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using RogueTemplate;
using UnityEngine;

public class TestEnvironment : MonoBehaviour
{
	public RLTileRenderer TileRenderer;
	public RLTileType floor;
	public RLTileType wall;

	public RLActorController ActorPrefab;
	public RLSkill move;
	private RLBaseTile[,] _tiles;
	private SimpleActor _actor;

	public CinemachineVirtualCamera virtualCam;
	
	public RLEffectRenderer effectRenderer;

	public bool CanMove;
	
	// Use this for initialization
	void Start () {
		_tiles = new RLBaseTile[10,10];
		for (int x = 0; x < 10; x++)
		{
			for (int y = 0; y < 10; y++)
			{
				_tiles[x,y] = new RLSimpleTile(new Vector3Int(x, y, 0), x == 0 || x == 9 || y == 0 || y == 9 ? wall : floor);
				TileRenderer.BindTile(_tiles[x,y]);
			}
		}

		_actor = new SimpleActor {BasicMoveSkill = move};
		_tiles[5, 5].SetActor(_actor);
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
