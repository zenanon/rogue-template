using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace RogueTemplate
{
	[CreateAssetMenu(fileName = "RLTileset", menuName = "RogueTemplate/RLTileset")]
	public class RLTileset : ScriptableObject
	{
		public TileEntry[] tiles;
		public TileBase tileNotFound;
		
		private Dictionary<int, TileBase> _tilesDict;

		private void Awake()
		{
			_tilesDict = new Dictionary<int, TileBase>(tiles.Length);
			foreach (TileEntry t in tiles)
			{
				_tilesDict[t.type.DisplayType] = t.displayTile;
			}
		}

		public TileBase this[int index]
		{
			get
			{
				TileBase displayTile;
				return _tilesDict.TryGetValue(index, out displayTile) ? displayTile : tileNotFound;
			}
		}

		[Serializable]
		public class TileEntry
		{
			public TileBase displayTile;
			public RLTileType type;
		}
	}
}