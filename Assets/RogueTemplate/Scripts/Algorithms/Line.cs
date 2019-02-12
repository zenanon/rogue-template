using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{
	public abstract class Line
	{
		public abstract List<RLBaseTile> LineBetween(Vector2Int fromPosition, Vector2Int toPosition, DungeonFloor floor);
	}
}