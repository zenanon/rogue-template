using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{
	[CreateAssetMenu(fileName = "ItemAssets", menuName = "RogueTemplate/ItemAssets")]
	public class ItemAssets : ScriptableObject
	{
		[SerializeField] public ItemAsset[] assets;
		public Sprite itemNotFoundSprite;

		private Dictionary<string, Sprite> _assetDict;

		private void Awake()
		{
			if (assets != null)
			{
				_assetDict = new Dictionary<string, Sprite>();
				foreach (ItemAsset asset in assets)
				{
					_assetDict[asset.displayName] = asset.itemSprite;
				}
			}
		}
		
		public Sprite this[string displayName]
		{
			get
			{
				Sprite displayTile;
				return _assetDict.TryGetValue(displayName, out displayTile) ? displayTile : itemNotFoundSprite;
			}
		}

		[Serializable]
		public class ItemAsset
		{
			public Sprite itemSprite;
			public string displayName;
		}
	}
}