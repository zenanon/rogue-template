using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{


	public class StatBlockDisplay : MonoBehaviour
	{
		public StatDisplay statDisplayPrefab;
		public RectTransform container;

		public void BindStatBlock(StatBlock statBlock)
		{
			foreach (Stat stat in statBlock.Stats)
			{
				StatDisplay display = Instantiate(statDisplayPrefab, container);
				display.BindStatBlock(stat, statBlock);
			}
		}
	}
}