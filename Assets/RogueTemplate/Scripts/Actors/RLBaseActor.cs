using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{
	public abstract class RLBaseActor
	{
		public delegate void ShowEffectsDelegate(string[] effects, RLBaseTile toTile, Action onComplete);

		public delegate void OnPositionChangedDelegate();

		public delegate void OnInventoryChangedDelegate();
		
		public OnInventoryChangedDelegate OnInventoryChanged { get; set; }

		public ShowEffectsDelegate ShowEffects { get; set; }

		private OnPositionChangedDelegate _onPositionChanged;
		public OnPositionChangedDelegate OnPositionChanged
		{
			get { return _onPositionChanged; }
			set
			{
				_onPositionChanged = value;
				if (_onPositionChanged != null)
				{
					_onPositionChanged();
				}
			}
		}

		public delegate void OnVisibilityChangedDelegate(RLBaseTile tile, bool visible);
		public OnVisibilityChangedDelegate OnVisibilityChanged { get; set; }
		
		public FieldOfView fieldOfView { get; set; }
		public List<RLBaseTile> visibleTiles { get; protected set; }
		
		public RLSkill BasicMoveSkill { get; set; }

		public abstract RLBaseTile GetTile();
		public abstract void SetTile(RLSimpleTile tile);

		public abstract int GetTeamId();
		public abstract List<RLSkill> GetSkills();
		
		public virtual bool IsAllyOf(RLBaseActor otherActor)
		{
			return GetTeamId() == otherActor.GetTeamId();
		}

		public virtual bool IsEnemyOf(RLBaseActor otherActor)
		{
			return GetTeamId() != otherActor.GetTeamId();
		}

		public void DoSkill(RLSkill skill, RLBaseTile target)
		{
			skill.DoSkill(this, target);
		}

		public virtual void TryBasicMoveToTile(RLBaseTile tile)
		{
			if (BasicMoveSkill != null && BasicMoveSkill.IsTargetValid(this, tile))
			{
				DoSkill(BasicMoveSkill, tile);
			}
		}

		public abstract int GetVisionRange();

		public virtual void UpdateVision()
		{
			if (fieldOfView == null)
			{
				return;
			}
			List<RLBaseTile> previousVisibility = new List<RLBaseTile>(visibleTiles);
			visibleTiles = fieldOfView.GetVisibleTilesForActor(this);
			List<RLBaseTile> newVisibility = new List<RLBaseTile>(visibleTiles);
			newVisibility.RemoveAll(tile => previousVisibility.Contains(tile));
			previousVisibility.RemoveAll(tile => visibleTiles.Contains(tile));

			foreach (RLBaseTile tile in previousVisibility)
			{
				if (OnVisibilityChanged != null)
				{
					OnVisibilityChanged(tile, false);
				}
			}
			
			foreach (RLBaseTile tile in newVisibility)
			{
				if (OnVisibilityChanged != null)
				{
					OnVisibilityChanged(tile, true);
				}
			}
		}

		public abstract StatBlock GetStats();

		public abstract IEnumerable<RLBaseItem> GetInventory();
	}
}