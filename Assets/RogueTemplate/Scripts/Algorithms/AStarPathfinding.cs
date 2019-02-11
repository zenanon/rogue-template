using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{
	public class AStarPathfinding : Pathfinding
	{
		public override List<RLBaseTile> FindPath(RLBaseTile fromTile,
			RLBaseTile to,
			DungeonFloor floor,
			CanMoveDelegate canMove,
			PathCostDelegate pathCost)
        {
            return AStarPathfind(floor, fromTile, to, canMove, pathCost);
        }

        private static List<RLBaseTile> AStarPathfind(DungeonFloor level, RLBaseTile start, RLBaseTile finish, CanMoveDelegate canMove, PathCostDelegate pathCost)
        {
            // A* Pathfinding
            Debug.Log("Connecting " + start.GetDisplayPosition() + " to " + finish.GetDisplayPosition() + " in " + level);
            List<RLBaseTile> closedSet = new List<RLBaseTile>();
            List<RLBaseTile> openSet = new List<RLBaseTile>();
            openSet.Add(start);
    
            Dictionary<RLBaseTile, RLBaseTile> cameFrom = new Dictionary<RLBaseTile, RLBaseTile>();
            Dictionary<RLBaseTile, float> gScore = new Dictionary<RLBaseTile, float>();
            gScore[start] = 0;
    
            Dictionary<RLBaseTile, float> fScore = new Dictionary<RLBaseTile, float>();
            fScore[start] = Mathf.Abs(start.GetDisplayPosition().x - finish.GetDisplayPosition().x) + Mathf.Abs(start.GetDisplayPosition().y - finish.GetDisplayPosition().y);
            int length = 0;
            while (openSet.Count > 0)
            {
                length++;
                openSet.Sort((first, second) =>
                {
                    float firstScore;
                    float secondScore;
                    if (!fScore.TryGetValue(first, out firstScore))
                    {
                        firstScore = float.PositiveInfinity;
                    }
                    if (!fScore.TryGetValue(second, out secondScore))
                    {
                        secondScore = float.PositiveInfinity;
                    }
                    if (firstScore < secondScore)
                    {
                        return -1;
                    }
                    else if (firstScore > secondScore)
                    {
                        return 1;
                    }
                    return 0;
                });
                RLBaseTile current = openSet[0];
                if (current == finish)
                {
                    // write and return path
                    List<RLBaseTile> hallTiles = ReconstructPath(current, cameFrom);
                    Debug.Log("Successful path from " + start.GetDisplayPosition() + " to " + finish.GetDisplayPosition());
                    return hallTiles;
                }
                openSet.Remove(current);
                closedSet.Add(current);

                List<RLBaseTile> neighbors = level.GetOrthogonalNeighborTiles(current);
                neighbors.RemoveAll((tile) => closedSet.Contains(tile) || !canMove(current, tile));
                foreach (RLBaseTile neighbor in neighbors)
                {
                    if (!openSet.Contains(neighbor))
                    {
                        openSet.Add(neighbor);
                    }
                    float neighborGscore;
                    if (!gScore.TryGetValue(neighbor, out neighborGscore))
                    {
                        neighborGscore = float.PositiveInfinity;
                    }
                    // currently using 1 as dist_between
                    float tentativeGScore = gScore[current] + pathCost(current, neighbor);
                    if (tentativeGScore >= neighborGscore)
                    {
                        continue;
                    }
                    cameFrom[neighbor] = current;
                    gScore[neighbor] = tentativeGScore;
                    fScore[neighbor] = gScore[neighbor] + Mathf.Abs(neighbor.GetDisplayPosition().x - finish.GetDisplayPosition().x) + Mathf.Abs(neighbor.GetDisplayPosition().y - finish.GetDisplayPosition().y);
                }
            }
            Debug.Log("Connection failed.");
            return new List<RLBaseTile>();
        }
    
        private static List<RLBaseTile> ReconstructPath(RLBaseTile finish, IDictionary<RLBaseTile, RLBaseTile> cameFrom)
        {
            List<RLBaseTile> path = new List<RLBaseTile> {finish};
            while (cameFrom.ContainsKey(finish))
            {
                finish = cameFrom[finish];
                path.Add(finish);
            }
            return path;
        }
	}
}