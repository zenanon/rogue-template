using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{
	[CreateAssetMenu(fileName = "DungeonGenerator", menuName = "RogueTemplate/DungeonGeneration/DungeonGenerator")]
	public class DungeonGenerator : ScriptableObject
	{
		public GenerationLayer[] generators;
		
		public DungeonFloor CreateFloor(Dungeon dungeon)
		{
			DungeonFloor dungeonFloor = new DungeonFloor(100, 100);

			List<DungeonRegion> dungeonRegions = new List<DungeonRegion>(dungeonFloor.Regions);
			foreach (GenerationLayer layer in generators)
			{
				List<DungeonRegion> newRegions = new List<DungeonRegion>();
				foreach (DungeonRegion region in dungeonRegions)
				{
					Debug.Log("Applying " + layer.name + " to region at " + region.Position.ToString() + " with size " + region.Size.ToString());
					newRegions.AddRange(layer.ApplyToRegion(dungeon, dungeonFloor, region));
				}
				dungeonRegions.Clear();
				dungeonRegions.AddRange(newRegions);
			}
			
			return dungeonFloor;
		}
	}
}