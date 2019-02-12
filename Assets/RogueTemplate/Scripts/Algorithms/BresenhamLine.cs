using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{
	public class BresenhamLine : Line
	{
        public override List<RLBaseTile> LineBetween(Vector2Int fromPosition, Vector2Int toPosition, DungeonFloor floor)
        {
            float deltaX = toPosition.x - fromPosition.x;
            float deltaY = toPosition.y - fromPosition.y;
            if (Mathf.Abs(deltaY) > Mathf.Abs(deltaX))
            {
                return LineHigh(fromPosition, toPosition, floor);
            }
            else
            {
                return LineLow(fromPosition, toPosition, floor);
            }
        }
    
        private List<RLBaseTile> LineLow(Vector2Int fromPosition, Vector2Int toPosition, DungeonFloor floor)
        {
            List<RLBaseTile> line = new List<RLBaseTile>();
            
            float deltaX = toPosition.x - fromPosition.x;
            float deltaY = toPosition.y - fromPosition.y;
            float deltaErr = 0;
            if (deltaX != 0)
            {
                deltaErr = Mathf.Abs(deltaY / deltaX);
            }
            float error = 0;
            int y = fromPosition.y;
            int i = 0;
            for (int x = fromPosition.x; i < Mathf.Abs(deltaX); x += ((int)Mathf.Sign(deltaX)), i++)
            {
                RLBaseTile tile = floor.GetTileAt(x, y);
                if (tile == null)
                {
                    return line;
                }
                line.Add(tile);
                error += deltaErr;
                while (error >= .5)
                {
                    y = y + ((int)Mathf.Sign(deltaY));
                    error--;
                }
            }

            return line;
        }
    
        private List<RLBaseTile> LineHigh(Vector2Int fromPosition, Vector2Int toPosition, DungeonFloor floor)
        {
            List<RLBaseTile> line = new List<RLBaseTile>();
            float deltaX = toPosition.x - fromPosition.x;
            float deltaY = toPosition.y - fromPosition.y;
            float deltaErr = 0;
            if (deltaY != 0)
            {
                deltaErr = Mathf.Abs(deltaX / deltaY);
            }
            float error = 0;
            int x = fromPosition.x;
            int i = 0;
            for (int y = fromPosition.y; i < Mathf.Abs(deltaY); y += ((int)Mathf.Sign(deltaY)), i++)
            {
                RLBaseTile tile = floor.GetTileAt(x, y);
                if (tile == null)
                {
                    return line;
                }
                line.Add(tile);
                error += deltaErr;
                while (error >= .5)
                {
                    x += ((int)Mathf.Sign(deltaX));
                    error--;
                }
            }

            return line;
        }

        
    }
}