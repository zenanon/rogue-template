using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using RogueTemplate;
using UnityEngine;

namespace RogueTemplate
{
	[CreateAssetMenu(fileName = "MoveVfx", menuName = "RogueTemplate/VFX/MoveVfx")]
	public class MoveVfx : RLVisualEffect
	{
		public override void ShowEffect(VisualEffectParams effectParams, Action onComplete)
		{
			Vector3 targetPosition = effectParams.FirstTarget.GetDisplayPosition();
			effectParams.ActorController.transform.DOMove(targetPosition, duration).OnComplete(() => onComplete());
		}
	}
}