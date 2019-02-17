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

		public override void BindData(Stat data)
		{
			int modValue = data.GetModifiers();
			int baseValue = data.GetBaseValue();

			string modString = modValue.ToString();

			nameText.text = data.shortName;
			
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