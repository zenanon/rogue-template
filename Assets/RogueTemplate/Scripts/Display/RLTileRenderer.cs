using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace RogueTemplate
{
	public class RLTileRenderer : MonoBehaviour
	{

		public Tilemap environmentTilemap;
		public Tilemap memoryFogTilemap;
		public Tilemap fogOfWarTilemap;
		
		public RLTileset tileset;

		private void Awake()
		{
			tileset = Instantiate(tileset);
		}

		public void BindTile(RLBaseTile tile)
		{
			tile.TileDisplayRefresh = DisplayTile;
		}

		private void DisplayTile(RLBaseTile tile)
		{
			environmentTilemap.SetTile(tile.GetDisplayPosition(), tileset[tile.GetDisplayType()]);
			memoryFogTilemap.SetTile(tile.GetDisplayPosition(), tile.IsCurrentlyVisibleToPlayer() ? null : tileset.memoryFogTile);
			fogOfWarTilemap.SetTile(tile.GetDisplayPosition(), tile.HasEverBeenSeenByPlayer() ? null : tileset.fogOfWarTile);
		}
	}
}