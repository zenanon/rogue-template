using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{
	public class SimpleActor : RLBaseActor
	{
		private RLBaseTile _tile;
		private int _teamId;
		private List<RLSkill> _skills;
		private StatBlock _stats;
		private List<RLBaseItem> _inventory;
		
		public SimpleActor(StatBlock stats)
		{
			visibleTiles = new List<RLBaseTile>();
			_stats = stats;
			_inventory = new List<RLBaseItem>();
		}
		
		public override RLBaseTile GetTile()
		{
			return _tile;
		}

		public override void SetTile(RLSimpleTile tile)
		{
			this._tile = tile;
			if (OnPositionChanged != null)
			{
				OnPositionChanged();
			}
			UpdateVision();
		}

		public override int GetTeamId()
		{
			return _teamId;
		}

		public override List<RLSkill> GetSkills()
		{
			return _skills;
		}

		public override int GetVisionRange()
		{
			// TODO: use a stat for this.
			return 10;
		}

		public override StatBlock GetStats()
		{
			return _stats;
		}

		public override IEnumerable<RLBaseItem> GetInventory()
		{
			return _inventory;
		}

		public void AddItem(RLBaseItem item)
		{
			_inventory.Add(item);
			if (OnInventoryChanged != null)
			{
				OnInventoryChanged();
			}
		}
	}
}