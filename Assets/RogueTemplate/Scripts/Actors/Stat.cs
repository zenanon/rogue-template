using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{
	[CreateAssetMenu(fileName = "Stat", menuName = "RogueTemplate/Actor/Stats/Stat")]
	public class Stat : ScriptableObject
	{
		public string Name;
		public string ShortName;
		[SerializeField] protected int baseValue;

		public virtual int GetValue()
		{
			return baseValue;
		}

		public virtual void ModifyValue(int amount)
		{
			baseValue += amount;
		}
	}
}