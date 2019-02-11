using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{
	
	[CreateAssetMenu(fileName = "EmptyRoomLayer", menuName = "RogueTemplate/DungeonGeneration/EmptyRoomLayer")]
	public class EmptyRoomLayer : GenerationLayer
	{
		public RLTileType wallType;
		public RLTileType floorType;

		public override void Apply(Dungeon dungeon, DungeonFloor floor)
		{
			foreach (DungeonRegion reg in floor.Regions)
			{
				DungeonRegion region = reg;
				floor.ForTilesInRegion(reg, (x, y, tile) =>
				{
					
					if (x == region.Position.x || x == region.Position.x + region.Size.x - 1
					                           || y == region.Position.y ||
					                           y == region.Position.y + region.Size.y - 1)
					{
						tile = new RLSimpleTile(new Vector3Int(x, y, 0), wallType);
					}
					else
					{
						tile = new RLSimpleTile(new Vector3Int(x, y, 0), floorType);
					}

					return tile;
				});
			}
		}
	}
}