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

		public RLSimpleTile(Vector3Int position, RLTileType type)
		{
			Position = position;
			TileType = type;
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
	}
}