using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{
	public abstract class GenerationLayer : ScriptableObject
	{
		public abstract void Apply(Dungeon dungeon, DungeonFloor floor);
	}
}