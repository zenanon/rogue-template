using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{
	[CreateAssetMenu(fileName = "PrefabVFX", menuName = "RogueTemplate/VFX/PrefabVFX")]
	public class SpawnPrefabVfx : RLVisualEffect
	{
		public TempVisualEffect prefab;
		public override void ShowEffect(VisualEffectParams effectParams, Action onComplete)
		{
			TempVisualEffect effect = Instantiate(prefab, effectParams.FirstTarget.GetDisplayPosition(), Quaternion.identity);
			effect.ShowFor(duration, onComplete);
		}
	}
}