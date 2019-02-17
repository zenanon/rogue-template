using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{


	public class StatBlockDisplay : AdapterView<Stat, StatDisplay>
	{
		private StatBlock _statBlock;
		public void BindStatBlock(StatBlock statBlock)
		{
			_statBlock = statBlock;
			BindDataList(new List<Stat>(statBlock.Stats));
		}

		public override void BindViewHolder(StatDisplay viewHolder, Stat data)
		{
			viewHolder.BindStatBlock(data, _statBlock);
		}
	}
}