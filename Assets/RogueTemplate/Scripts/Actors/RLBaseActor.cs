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
	}
}