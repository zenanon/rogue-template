using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{
	public abstract class RLSkillEffect : ScriptableObject
	{
		public abstract void DoEffect(RLBaseActor actor, RLBaseTile target, Action onComplete);
	}
}