using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{
	public abstract class StatDisplay : MonoBehaviour
	{
		protected Stat Stat;

		public void BindStatBlock(Stat stat, StatBlock block)
		{
			Stat = stat;
			block.OnStatsChanged += OnStatChanged;
			OnStatChanged(block);
		}

		public abstract void OnStatChanged(StatBlock block);
	}
}