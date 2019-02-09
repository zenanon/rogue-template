using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{
	[CreateAssetMenu(fileName = "MoveEffect", menuName = "RogueTemplate/Skills/Effects/MoveEffect")]
	public class MoveEffect : RLSkillEffect
	{
		public override void DoEffect(RLBaseActor user, RLBaseTile target, Action onComplete)
		{
			target.SetActor(user);
			onComplete();
		}
	}
}