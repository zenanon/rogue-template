using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{
	public abstract class RLItemBehaviour : ScriptableObject
	{
		public string behaviourName;

		public virtual string GetBehaviourName()
		{
			return behaviourName;
		}
		public abstract bool CanUse(RLBaseActor user);
		public abstract bool ShowBehaviour(RLBaseActor user);
		public abstract void OnUse(RLBaseActor user);
	}
}