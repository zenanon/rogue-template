using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{
	public class DungeonRegion
	{
		public Vector2Int Position { get; private set; }
		public Vector2Int Size { get; private set; }
		public List<string> Tags { get; private set; }
		public List<DungeonRegion> Neighbors { get; private set; }

		public DungeonRegion(Vector2Int position, Vector2Int size)
		{
			Position = position;
			Size = size;
			Tags = new List<string>();
			Neighbors = new List<DungeonRegion>();
		}
	}
}