using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{

	[CreateAssetMenu(fileName = "Item", menuName = "RogueTemplate/Items/Item")]
	public class RLBaseItem : ScriptableObject
	{
		public string itemName;
		public string displayType;
		public RLItemBehaviour[] itemBehaviours;

	}
}