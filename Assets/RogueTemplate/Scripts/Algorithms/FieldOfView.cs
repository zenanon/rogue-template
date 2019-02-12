using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{
	public abstract class FieldOfView
	{
		public virtual List<RLBaseTile> GetVisibleTilesForActor(RLBaseActor actor)
		{
			Vector2Int pos = new Vector2Int(actor.GetTile().GetDisplayPosition().x, actor.GetTile().GetDisplayPosition().y);
			return GetVisibleTilesFromPosition(pos, actor.GetVisionRange(), actor.GetTile().Floor);
		}
		
		public abstract List<RLBaseTile> GetVisibleTilesFromPosition(Vector2Int fromPosition, int sightRange, DungeonFloor floor);

		protected bool CanSeeThrough(RLBaseTile tile)
		{
			return !tile.GetTileType().BlocksVision;
		}
	}
}