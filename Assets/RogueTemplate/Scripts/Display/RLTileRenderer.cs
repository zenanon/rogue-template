using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace RogueTemplate
{
	public class RLTileRenderer : MonoBehaviour
	{

		public Tilemap environmentTilemap;
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
		}
	}
}