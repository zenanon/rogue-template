using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{
	public class SimpleActor : RLBaseActor
	{
		private RLBaseTile tile;
		private int teamId;
		private List<RLSkill> skills;

		public SimpleActor()
		{
			visibleTiles = new List<RLBaseTile>();
		}
		
		public override RLBaseTile GetTile()
		{
			return tile;
		}

		public override void SetTile(RLSimpleTile tile)
		{
			this.tile = tile;
			if (OnPositionChanged != null)
			{
				OnPositionChanged();
			}
			UpdateVision();
		}

		public override int GetTeamId()
		{
			return teamId;
		}

		public override List<RLSkill> GetSkills()
		{
			return skills;
		}

		public override int GetVisionRange()
		{
			// TODO: use a stat for this.
			return 10;
		}
	}
}