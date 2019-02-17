using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RogueTemplate
{
	public class ItemBehaviourDisplay : MonoBehaviour
	{
		public Text behaviourName;

		public void BindBehaviour(RLItemBehaviour itemBehaviour)
		{
			behaviourName.text = itemBehaviour.GetBehaviourName();
		}
	}
}