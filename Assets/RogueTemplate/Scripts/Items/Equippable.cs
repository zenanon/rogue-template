using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{

	[CreateAssetMenu(fileName = "Equippable", menuName = "RogueTemplate/Items/Equippable")]
	public class Equippable : RLItemBehaviour
	{
		public bool isEquipped;
		public StatMod[] statMods;
		
		public override bool CanUse(RLBaseActor user)
		{
			return true;
		}

		public override bool ShowBehaviour(RLBaseActor user)
		{
			return true;
		}

		public override string GetBehaviourName()
		{
			return isEquipped ? "Unequip" : "Equip";
		}

		public override void OnUse(RLBaseActor user)
		{	
			if (!isEquipped)
			{
				isEquipped = true;
				foreach (StatMod mod in statMods) {
					user.GetStats().AddModifier(mod);
				}
			}
			else
			{
				isEquipped = false;
				foreach (StatMod mod in statMods) {
					user.GetStats().RemoveModifier(mod);
				}
			}
		}
	}
}