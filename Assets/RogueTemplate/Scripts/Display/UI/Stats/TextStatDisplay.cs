using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RogueTemplate
{
	public class TextStatDisplay : StatDisplay
	{
		public Text nameText;
		public Text valueText;

		public Color neutralColor;
		public Color negativeColor;
		public Color positiveColor;
		
		public override void OnStatChanged(StatBlock block)
		{
			int modValue = block.GetTotalModifers(Stat.Name);
			int baseValue = block.GetBaseStatValue(Stat.Name);

			string modString = modValue.ToString();

			nameText.text = Stat.ShortName;
			
			if (modValue < 0)
			{
				valueText.color = negativeColor;
			} else if (modValue > 0)
			{
				valueText.color = positiveColor;
				modString = "+" + modString;
			}
			else
			{
				valueText.color = neutralColor;
				modString = "";
			}

			valueText.text = baseValue + modString;
		}
	}
}