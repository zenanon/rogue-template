using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{
	[CreateAssetMenu(fileName = "ConnectNeighborsLayer", menuName = "RogueTemplate/DungeonGeneration/ConnectNeighborsLayer")]
	public class ConnectNeighborsLayer : GenerationLayer
	{
		public RLTileType hallwayFloor;
		public RLTileType hallwayWall;
		public override void Apply(Dungeon dungeon, DungeonFloor floor)
		{
			List<DungeonRegion> unconnected = new List<DungeonRegion>(floor.Regions);
			
			Pathfinding pathfinder = new AStarPathfinding();

			foreach (DungeonRegion region in floor.Regions)
			{
				List<RLBaseTile> floorTiles = new List<RLBaseTile>();
				floor.ForTilesInRegion(region, (x, y, tile) =>
				{
					if (!tile.GetTileType().BlocksMovement)
					{
						floorTiles.Add(tile);
					}
					return tile;
				});
				foreach (DungeonRegion neighbor in region.Neighbors)
				{
					
					
					if (!unconnected.Contains(neighbor))
					{
						List<RLBaseTile> neighborFloorTiles = new List<RLBaseTile>();
						floor.ForTilesInRegion(neighbor, (x, y, tile) =>
						{
							if (!tile.GetTileType().BlocksMovement)
							{
								neighborFloorTiles.Add(tile);
							}
							return tile;
						});

						if (floorTiles.Count > 0 && neighborFloorTiles.Count > 0)
						{
							List<RLBaseTile> hall = pathfinder.FindPath(floorTiles[Random.Range(0, floorTiles.Count)],
								neighborFloorTiles[Random.Range(0, neighborFloorTiles.Count)], floor,
								(from, to) => true, ((from, to) => 1f));

							foreach (RLBaseTile tile in hall)
							{
								if (tile.GetTileType().BlocksMovement)
								{
									floor.Tiles[tile.GetDisplayPosition().x, tile.GetDisplayPosition().y] =
										new RLSimpleTile(tile.GetDisplayPosition(), hallwayFloor);
								}
							}
						}

						unconnected.Remove(neighbor);
					}
				}

				unconnected.Remove(region);
			}
			
		}
	}
}