using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{
	public class RLSimpleTile : RLBaseTile
	{
		private Vector3Int Position { get; set; }

		private int DisplayType
		{
			get { return TileType.DisplayType; }
		}

		private RLTileType TileType { get; set; }

		private RLBaseActor Actor { get; set; }

		private bool currentlyVisible;
		private bool everSeen;
		

		public RLSimpleTile(Vector3Int position, RLTileType type, DungeonFloor floor)
		{
			Position = position;
			TileType = type;
			Floor = floor;
		}
		
		public override Vector3Int GetDisplayPosition()
		{
			return Position;
		}

		public override int GetDisplayType()
		{
			return DisplayType;
		}

		public override RLBaseActor GetActor()
		{
			return Actor;
		}

		public override void SetActor(RLBaseActor actor)
		{
			if (actor == Actor)
			{
				return;
			}
			Actor = actor;
			if (Actor != null)
			{
				if (Actor.GetTile() != null)
				{
					Actor.GetTile().SetActor(null);
				}

				Actor.SetTile(this);
			}
		}

		public override RLTileType GetTileType()
		{
			return TileType;
		}

		public override void SetTileType(RLTileType type)
		{
			TileType = type;
			if (TileDisplayRefresh != null)
			{
				TileDisplayRefresh(this);
			}
		}

		public override void SetCurrentlyVisibleToPlayer(bool visible)
		{
			currentlyVisible = visible;
			if (TileDisplayRefresh != null)
			{
				TileDisplayRefresh(this);
			}
		}

		public override void SetEverSeenByPlayer(bool visible)
		{
			everSeen = visible;
			if (TileDisplayRefresh != null)
			{
				TileDisplayRefresh(this);
			}
		}

		public override bool IsCurrentlyVisibleToPlayer()
		{
			return currentlyVisible;
		}

		public override bool HasEverBeenSeenByPlayer()
		{
			return everSeen;
		}
	}
}