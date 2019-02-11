using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{
	public abstract class Pathfinding
	{
		public delegate bool CanMoveDelegate(RLBaseTile from, RLBaseTile to);
		public delegate float PathCostDelegate(RLBaseTile from, RLBaseTile to);
		public abstract List<RLBaseTile> FindPath(RLBaseTile from, RLBaseTile to, DungeonFloor floor, CanMoveDelegate canMove, PathCostDelegate pathCost);
	}
}