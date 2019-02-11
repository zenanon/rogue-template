using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{
	[CreateAssetMenu(fileName = "BSPLayer", menuName = "RogueTemplate/DungeonGeneration/BSPLayer")]
	public class BSPLayer : GenerationLayer
	{
		public Vector2Int minDimensions;
		public int splitVariance;
		public bool splitHorizontally = true;
		public bool splitVertically = true;
		
		public override void Apply(Dungeon dungeon, DungeonFloor floor)
		{
			List<DungeonRegion> toSplit = new List<DungeonRegion>(floor.Regions);
			List<DungeonRegion> added = new List<DungeonRegion>();
			floor.Regions.Clear();
			while (toSplit.Count > 0)
			{
				foreach (DungeonRegion reg in toSplit)
				{
					if (CanSplitVertically(reg) || CanSplitHorizontally(reg))
					{
						added.AddRange(Split(reg));
					}
					else
					{
						floor.Regions.Add(reg);
					}
				}
				
				toSplit.Clear();
				toSplit.AddRange(added);
				added.Clear();
			}
		}

		private DungeonRegion[] Split(DungeonRegion region)
		{
			if (CanSplitVertically(region) && CanSplitHorizontally(region))
			{
				return Random.Range(0f, 1f) < .5f ? SplitVertically(region) : SplitHorizontally(region);
			}

			return CanSplitVertically(region) ? SplitVertically(region) : SplitHorizontally(region);
		}

		private DungeonRegion[] SplitHorizontally(DungeonRegion region)
		{
			int leftWidth = region.Size.x / 2 + Random.Range(-splitVariance, splitVariance + 1);
			DungeonRegion left = new DungeonRegion(new Vector2Int(region.Position.x, region.Position.y), 
				new Vector2Int(leftWidth, region.Size.y));
			left.Tags.AddRange(region.Tags);
			DungeonRegion right = new DungeonRegion(new Vector2Int(region.Position.x + leftWidth, region.Position.y), 
				new Vector2Int(region.Size.x - leftWidth, region.Size.y));
			right.Tags.AddRange(region.Tags);
			
			left.Neighbors.Add(right);
			right.Neighbors.Add(left);
			foreach (DungeonRegion neighbor in region.Neighbors)
			{
				neighbor.Neighbors.Remove(region);
				DungeonRegion newNeighbor = Random.Range(0f, 1f) < .5f ? left : right;
				newNeighbor.Neighbors.Add(neighbor);
				neighbor.Neighbors.Add(newNeighbor);
			}
			return new[] {left, right};
		}
		
		private DungeonRegion[] SplitVertically(DungeonRegion region)
		{
			int bottomHeight = region.Size.y / 2 + Random.Range(-splitVariance, splitVariance + 1);
			DungeonRegion bottom = new DungeonRegion(new Vector2Int(region.Position.x, region.Position.y), 
				new Vector2Int(region.Size.x, bottomHeight));
			bottom.Tags.AddRange(region.Tags);
			DungeonRegion top = new DungeonRegion(new Vector2Int(region.Position.x, region.Position.y + bottomHeight), 
				new Vector2Int(region.Size.x, region.Size.y - bottomHeight));
			top.Tags.AddRange(region.Tags);
			
			bottom.Neighbors.Add(top);
			top.Neighbors.Add(bottom);
			foreach (DungeonRegion neighbor in region.Neighbors)
			{
				neighbor.Neighbors.Remove(region);
				DungeonRegion newNeighbor = Random.Range(0f, 1f) < .5f ? top : bottom;
				newNeighbor.Neighbors.Add(neighbor);
				neighbor.Neighbors.Add(newNeighbor);
			}
			return new[] {bottom, top};
		}

		private bool CanSplitHorizontally(DungeonRegion region)
		{
			return splitHorizontally && region.Size.x > minDimensions.x;
		}

		private bool CanSplitVertically(DungeonRegion region)
		{
			return splitVertically && region.Size.y > minDimensions.y;
		}
	}
}