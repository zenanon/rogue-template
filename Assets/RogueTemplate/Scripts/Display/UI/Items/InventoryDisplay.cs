using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{
	public class InventoryDisplay : MonoBehaviour
	{
		public RectTransform itemDisplayContainer;
		public ItemDisplay itemDisplayPrefab;
		public ItemAssets itemAssets;

		private void Start()
		{
			itemAssets = Instantiate(itemAssets);
		}

		public void BindInventory(RLBaseActor actor)
		{
			actor.OnInventoryChanged = () => DisplayInventory(actor);
			DisplayInventory(actor);
		}

		private void DisplayInventory(RLBaseActor actor)
		{
			for (int i = 0; i < itemDisplayContainer.childCount; i++)
			{
				Destroy(itemDisplayContainer.GetChild(i).gameObject);
			}

			foreach (RLBaseItem item in actor.GetInventory())
			{
				ItemDisplay itemDisplay = Instantiate(itemDisplayPrefab, itemDisplayContainer);
				itemDisplay.ItemAssets = itemAssets;
				itemDisplay.BindItem(item);
			}
		}
	}
}