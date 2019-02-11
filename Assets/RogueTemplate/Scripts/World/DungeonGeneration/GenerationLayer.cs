using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{
	public abstract class GenerationLayer : ScriptableObject
	{
		public abstract List<DungeonRegion> ApplyToRegion(Dungeon dungeon, DungeonFloor floor, DungeonRegion region);
	}
}