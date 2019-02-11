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
        public override List<DungeonRegion> ApplyToRegion(Dungeon dungeon, DungeonFloor floor, DungeonRegion region)
        {
            if (region.Size.x < minWidth || region.Size.y < minHeight)
            {
                return new List<DungeonRegion>();
            }

            return new List<DungeonRegion> {region};
        }
    }
}