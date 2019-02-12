using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RogueTemplate
{
	public class BresenhamFOV : FieldOfView
	{

		public override List<RLBaseTile> GetVisibleTilesFromPosition(Vector2Int fromPosition, int sightRange, DungeonFloor floor)
		{
			BresenhamLine bresenhamLine = new BresenhamLine();
			List<RLBaseTile> visibleTiles = new List<RLBaseTile>();
			List<Vector2Int> outerTiles = new List<Vector2Int>();
			for (int i = 0; i < sightRange; i++)
			{
				outerTiles.Add(new Vector2Int(fromPosition.x + sightRange, fromPosition.y + i));
				outerTiles.Add(new Vector2Int(fromPosition.x + sightRange, fromPosition.y - i));
				outerTiles.Add(new Vector2Int(fromPosition.x - sightRange, fromPosition.y + i));
				outerTiles.Add(new Vector2Int(fromPosition.x - sightRange, fromPosition.y - i));
				outerTiles.Add(new Vector2Int(fromPosition.x + i, fromPosition.y + sightRange));
				outerTiles.Add(new Vector2Int(fromPosition.x - i, fromPosition.y + sightRange));
				outerTiles.Add(new Vector2Int(fromPosition.x + i, fromPosition.y - sightRange));
				outerTiles.Add(new Vector2Int(fromPosition.x - i, fromPosition.y - sightRange));
			}

			outerTiles = outerTiles.Distinct().ToList();
			foreach (Vector2Int vision in outerTiles)
			{
				List<RLBaseTile> lineTiles = bresenhamLine.LineBetween(fromPosition, vision, floor);
				foreach (RLBaseTile tile in lineTiles)
				{
					if (!visibleTiles.Contains(tile))
					{
						visibleTiles.Add(tile);
					}
					if (!CanSeeThrough(tile))
					{
						break;
					}
				}
			}
			return visibleTiles;
		}
	}
}