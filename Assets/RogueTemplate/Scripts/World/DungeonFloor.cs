using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{
	public class DungeonFloor
	{
		public delegate RLBaseTile TileDecoratorDelegate(int x, int y, RLBaseTile tile);
		
		public List<string> Tags { get; protected set; }

		public List<DungeonRegion> Regions { get; protected set; }

		public RLBaseTile[,] Tiles { get; protected set; }

		public DungeonFloor(int width, int height)
		{
			Tags = new List<string>();
			Regions = new List<DungeonRegion> {new DungeonRegion(new Vector2Int(0, 0), new Vector2Int(width, height))};
			Tiles = new RLBaseTile[width, height];
		}

		public void ForTilesInRegion(DungeonRegion region, TileDecoratorDelegate tileDecoratorDelegate)
		{
			for (int x = region.Position.x; x < region.Position.x + region.Size.x; x++)
			{
				for (int y = region.Position.y; y < region.Position.y + region.Size.y; y++)
				{
					Tiles[x, y] = tileDecoratorDelegate(x, y, Tiles[x, y]);
				}
			}
		}

	}
}