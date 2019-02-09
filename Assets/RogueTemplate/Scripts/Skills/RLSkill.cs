using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{
	[CreateAssetMenu(fileName = "Skill", menuName = "RogueTemplate/Skills/Skill")]
	public class RLSkill : ScriptableObject
	{
		public enum TargetType
		{
			None,
			Any,
			EmptyTile,
			Self,
			AnyCreature,
			Enemy,
			Ally,
			Custom
		}

		public RLSkillEffect[] skillEffects;

		[SerializeField] private TargetType target;
		public TargetType Target
		{
			get { return target; }
			protected set { target = value; }
		}

		[SerializeField] private int range;
		public int Range
		{
			get { return range; }

			protected set { range = value; }
		}

		[SerializeField] private bool needsLineOfSight;
		public bool NeedsLineOfSight
		{
			get { return needsLineOfSight; }
			protected set { needsLineOfSight = value; }
		}

		/**
		 * If the skill needs custom targeting logic not covered by one of the enumerated cases in TargetType,
		 * override this method to return true for valid targets.
		 */
		protected virtual bool IsCustomTargetValid(RLBaseActor skillUser, RLBaseTile targetTile)
		{
			return false;
		}

		public bool IsTargetValid(RLBaseActor skillUser, RLBaseTile targetTile)
		{
			if (!IsTargetInRange(skillUser, targetTile))
			{
				return false;
			}
			switch (Target)
			{
				case TargetType.None:
					return false;
				case TargetType.Any:
					return true;
				case TargetType.EmptyTile:
					return !targetTile.GetTileType().BlocksMovement && targetTile.GetActor() == null;
				case TargetType.Self:
					return true;
				case TargetType.AnyCreature:
					return targetTile.GetActor() != null;
				case TargetType.Enemy:
					return targetTile.GetActor() != null && skillUser.IsEnemyOf(targetTile.GetActor());
				case TargetType.Ally:
					return targetTile.GetActor() != null && skillUser.IsAllyOf(targetTile.GetActor());
				case TargetType.Custom:
					return IsCustomTargetValid(skillUser, targetTile);
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public virtual bool IsTargetInRange(RLBaseActor skillUser, RLBaseTile targetTile)
		{
			return range <= 0 || Vector3.Distance(skillUser.GetTile().GetDisplayPosition(), targetTile.GetDisplayPosition()) <= range;
		}

		public void DoSkill(RLBaseActor user, RLBaseTile targetTile)
		{
			DoSkillEffect(0, user, targetTile);
		}

		private void DoSkillEffect(int index, RLBaseActor user, RLBaseTile targetTile)
		{
			if (index < skillEffects.Length)
			{
				skillEffects[index].DoEffect(user, targetTile, () => {DoSkillEffect(index + 1, user, targetTile);});
			}
		}
	}
}