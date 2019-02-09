using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace RogueTemplate
{
	public class RLActorController : MonoBehaviour
	{
		public RLEffectRenderer effectRenderer;
		
		public void BindActor(RLBaseActor actor)
		{
			actor.ShowEffects = (effects, target, onComplete) => ShowEffects(effects, actor, target, onComplete);
			actor.OnPositionChanged = () => transform.position = actor.GetTile().GetDisplayPosition();
		}

		private void ShowEffects(string[] effects, RLBaseActor actor, RLBaseTile target, Action onComplete)
		{
			RLVisualEffect.VisualEffectParams effectParams = new RLVisualEffect.VisualEffectParams()
			{
				From = actor.GetTile(),
				Targets = new List<RLBaseTile>(new[] {target}),
				ActorController = this
			};
			
			effectRenderer.ShowEffects(effects, effectParams, onComplete);
		}
	}
}