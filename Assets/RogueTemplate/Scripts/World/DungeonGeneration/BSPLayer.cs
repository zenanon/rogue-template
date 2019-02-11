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
		
		public override List<DungeonRegion> ApplyToRegion(Dungeon dungeon, DungeonFloor floor, DungeonRegion region)
		{
			List<DungeonRegion> subregions = new List<DungeonRegion>();
			
			List<DungeonRegion> toSplit = new List<DungeonRegion>(new[]{region});
			List<DungeonRegion> added = new List<DungeonRegion>();
			while (toSplit.Count > 0)
			{
				foreach (DungeonRegion reg in toSplit)
				{
					if (!CanSplitVertically(reg) && !CanSplitHorizontally(reg))
					{
						subregions.Add(reg);
					}
					else
					{
						added.AddRange(Split(reg));
					}
				}
				
				toSplit.Clear();
				toSplit.AddRange(added);
				added.Clear();
			}
			
			return subregions;
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