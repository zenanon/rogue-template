using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{
	[CreateAssetMenu(fileName = "DungeonGenerator", menuName = "RogueTemplate/DungeonGeneration/DungeonGenerator")]
	public class DungeonGenerator : ScriptableObject
	{
		public GenerationLayer[] generators;
		public RLTileType defaultTileType;
		
		public DungeonFloor CreateFloor(int width, int height, Dungeon dungeon)
		{
			DungeonFloor dungeonFloor = new DungeonFloor(width, height, defaultTileType);

			List<DungeonRegion> dungeonRegions = new List<DungeonRegion>(dungeonFloor.Regions);
			foreach (GenerationLayer layer in generators)
			{
				layer.Apply(dungeon, dungeonFloor);
			}
			
			return dungeonFloor;
		}
	}
}