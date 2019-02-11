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

		public DungeonFloor(int width, int height, RLTileType defaultType)
		{
			Tags = new List<string>();
			DungeonRegion mainRegion = new DungeonRegion(new Vector2Int(0, 0), new Vector2Int(width, height));
			Regions = new List<DungeonRegion> {mainRegion};
			Tiles = new RLBaseTile[width, height];
			ForTilesInRegion(mainRegion, (x, y, tile) => new RLSimpleTile(new Vector3Int(x, y, 0), defaultType));
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

		public List<RLBaseTile> GetOrthogonalNeighborTiles(RLBaseTile tile)
		{
			List<Vector2Int> neighborDirections = new List<Vector2Int>
				{Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left};

			return GetNeighborTiles(tile, neighborDirections);
		}

		public List<RLBaseTile> GetAllNeighborTiles(RLBaseTile tile)
		{
			List<Vector2Int> neighborDirections = new List<Vector2Int>
				{Vector2Int.up, Vector2Int.up + Vector2Int.right, Vector2Int.right, Vector2Int.right + Vector2Int.down,
					Vector2Int.down, Vector2Int.down + Vector2Int.left, Vector2Int.left, Vector2Int.left + Vector2Int.up};

			return GetNeighborTiles(tile, neighborDirections);
		}

		private List<RLBaseTile> GetNeighborTiles(RLBaseTile tile, List<Vector2Int> directions)
		{
			int x = tile.GetDisplayPosition().x;
			int y = tile.GetDisplayPosition().y;
			
			List<RLBaseTile> neighbors = new List<RLBaseTile>();
			foreach (Vector2Int direction in directions)
			{
				int nX = x + direction.x;
				int nY = y + direction.y;

				if (nX >= 0 && nX < Tiles.GetLength(0) && nY >= 0 && nY < Tiles.GetLength(1))
				{
					neighbors.Add(Tiles[nX, nY]);
				}
			}

			return neighbors;
		}
		
	}
}