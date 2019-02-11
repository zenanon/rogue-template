using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{
    
    [CreateAssetMenu(fileName = "PruneSmallRegionsLayer", menuName = "RogueTemplate/DungeonGeneration/PruneSmallRegionsLayer")]
    public class PruneSmallRegionsLayer : GenerationLayer
    {
        public int minWidth;
        public int minHeight;
        public override void Apply(Dungeon dungeon, DungeonFloor floor)
        {
            List<DungeonRegion> pruned = new List<DungeonRegion>();
            foreach (DungeonRegion region in floor.Regions)
            {
                if (region.Size.x < minWidth || region.Size.y < minHeight)
                {
                    pruned.Add(region);
                    if (region.Neighbors.Count > 0)
                    {
                        DungeonRegion inheritor = region.Neighbors[Random.Range(0, region.Neighbors.Count)];
                        region.Neighbors.Remove(inheritor);
                        inheritor.Neighbors.Remove(region);
                        foreach (DungeonRegion neighbor in region.Neighbors)
                        {
                            neighbor.Neighbors.Remove(region);
                            inheritor.Neighbors.Add(neighbor);
                            neighbor.Neighbors.Add(inheritor);
                        }
                    }
                }
            }

            floor.Regions.RemoveAll(region => pruned.Contains(region));
        }
    }
}