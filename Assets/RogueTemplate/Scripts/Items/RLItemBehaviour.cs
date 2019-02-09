using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{
	public abstract class RLItemBehaviour
	{
		public string Name { get; protected set; }
		public bool ShowsInItemMenu { get; protected set; }
		public int OrderInMenu { get; protected set; }

		public abstract bool CanUse(RLBaseActor user);
		public abstract void OnUse(RLBaseActor user);
	}
}