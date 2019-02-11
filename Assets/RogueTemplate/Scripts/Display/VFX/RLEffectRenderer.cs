using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RogueTemplate
{
	public class RLEffectRenderer : MonoBehaviour
	{
		public bool failOnNotFound;
		[SerializeField] private RLVisualEffect[] effects;

		private Dictionary<string, RLVisualEffect> _effectsDict;
		
		private void Awake()
		{
			_effectsDict = new Dictionary<string, RLVisualEffect>(effects.Length);
			foreach (RLVisualEffect effect in effects)
			{
				_effectsDict[effect.effectName] = effect;
			}
		}

		public void ShowEffect(string effect, RLVisualEffect.VisualEffectParams effectParams, Action onComplete)
		{
			ShowEffects(new[] {effect}, effectParams, onComplete);
		}
		
		public void ShowEffects(string[] effectTypes, RLVisualEffect.VisualEffectParams effectParams, Action onComplete)
		{
			List<RLVisualEffect> effectList = new List<RLVisualEffect>(effectTypes.Length);
			effectList.AddRange(from effectName in effectTypes select _effectsDict[effectName]);
			ShowEffectChain(effectParams, effectList, 0, onComplete);
		}

		private void ShowEffectChain(RLVisualEffect.VisualEffectParams effectParams, IList<RLVisualEffect> effectList, int effectIndex,
			Action onComplete)
		{
			if (effectIndex >= effectList.Count)
			{
				if (onComplete != null)
				{
					onComplete();
				}

				return;
			}
			
			effectList[effectIndex].ShowEffect(effectParams, () =>
			{
				ShowEffectChain(effectParams, effectList, effectIndex + 1, onComplete);
			});
		}
	}
}