using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{
	public class ItemInteractor : MonoBehaviour
	{
		private RLBaseItem _item;

		public void BindItem(RLBaseItem item)
		{
			_item = item;
		}
	}
}