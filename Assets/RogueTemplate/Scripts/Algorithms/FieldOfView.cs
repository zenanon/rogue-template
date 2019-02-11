using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{
	public abstract class FieldOfView
	{
		public delegate bool CanSeeThrough(RLBaseTile tile);

		public abstract List<RLBaseTile> GetVisibleTilesForActor(RLBaseActor actor);
		public abstract List<RLBaseTile> GetVisibleTilesFromPosition(RLBaseTile from, int sightRange);
	}
}