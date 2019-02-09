using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{

	[CreateAssetMenu(fileName = "VFX", menuName = "RogueTemplate/Skills/Effects/VFX")]
	public class VfxEffect : RLSkillEffect
	{
		public string[] vfx;
		public override void DoEffect(RLBaseActor actor, RLBaseTile target, Action onComplete)
		{
			actor.ShowEffects(vfx, target, onComplete);
		}
	}
}