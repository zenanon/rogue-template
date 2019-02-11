using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{
	public abstract class RLVisualEffect : ScriptableObject
	{
		public float duration;
		public string effectName;
		public abstract void ShowEffect(VisualEffectParams effectParams, Action onComplete);

		public class VisualEffectParams
		{
			public RLActorController ActorController;
			public RLBaseTile From;
			public List<RLBaseTile> Targets = new List<RLBaseTile>();

			public RLBaseTile FirstTarget
			{
				get { return Targets[0]; }
			}
		}
	}
}