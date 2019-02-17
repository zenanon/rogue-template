using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{
	public class InventoryDisplay : AdapterView<RLBaseItem, ItemDisplay>
	{
		public ItemAssets itemAssets;

		private void Start()
		{
			itemAssets = Instantiate(itemAssets);
		}

		public void BindInventory(RLBaseActor actor)
		{
			actor.OnInventoryChanged = () => BindDataList(new List<RLBaseItem>(actor.GetInventory()));
			BindDataList(new List<RLBaseItem>(actor.GetInventory()));
		}

		public override ItemDisplay CreateViewHolder()
		{
			ItemDisplay viewHolder = base.CreateViewHolder();
			viewHolder.ItemAssets = itemAssets;	
			return viewHolder;
		}
	}
}