using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{
	public abstract class StatDisplay : ViewHolder<Stat>
	{
		public void BindStatBlock(Stat stat, StatBlock block)
		{
			block.OnStatsChanged += (statBlock => BindData(stat));
			BindData(stat);
		}
	}
}