using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RogueTemplate
{
	public class ItemDisplay : MonoBehaviour
	{
		public Image image;
		public Text itemName;
		public Text itemDescription;

		public ItemInteractor itemInteractor;

		public ItemAssets ItemAssets { get; set; }

		public void BindItem(RLBaseItem item)
		{
			if (image != null)
			{
				image.sprite = ItemAssets[item.displayType];
			}

			if (itemName != null)
			{
				itemName.text = item.itemName;
			}

			if (itemInteractor != null)
			{
				itemInteractor.BindItem(item);
			}
		}
	}
}