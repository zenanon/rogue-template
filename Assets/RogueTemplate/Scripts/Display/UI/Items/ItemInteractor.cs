using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{
	public class ItemInteractor : MonoBehaviour
	{
		private RLBaseItem _item;
		public RectTransform container;

		public ItemBehaviourDisplay behaviourDisplayPrefab;

		public void BindItem(RLBaseItem item)
		{
			_item = item;
			foreach (RLItemBehaviour behaviour in item.itemBehaviours)
			{
				Instantiate(behaviourDisplayPrefab, container);
			}
		}
	}
}