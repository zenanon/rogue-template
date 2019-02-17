using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{
	[CreateAssetMenu(fileName = "Stat", menuName = "RogueTemplate/Actor/Stats/Stat")]
	public class Stat : ScriptableObject
	{
		public delegate void OnStatChangedDelegate(Stat stat);
		public OnStatChangedDelegate OnStatChanged { get; set; }
		public string statName;
		public string shortName;
		public StatBlock statBlock;
		[SerializeField] protected int baseValue;
		private readonly List<StatMod> _mods = new List<StatMod>();

		public virtual int GetBaseValue()
		{
			return baseValue;
		}

		public virtual int GetTotalValue()
		{
			return GetBaseValue() + GetModifiers();
		}

		public virtual int GetModifiers()
		{
			int flatAmount = 0;
			float percent = 0f;
			
			foreach (StatMod mod in _mods)
			{
				flatAmount += mod.flatAmount;
				percent += mod.percentAmount;
			}
			
			return (int) (GetBaseValue() * percent + flatAmount);
		}

		public virtual void SetBaseValue(int amount)
		{
			baseValue = amount;
			NotifyStatChanged();
		}
		
		public virtual void ModifyValue(int amount)
		{
			baseValue += amount;
			NotifyStatChanged();
		}

		public virtual void AddModifier(StatMod mod)
		{
			_mods.Add(mod);
			NotifyStatChanged();
		}

		public virtual void RemoveModifier(StatMod mod)
		{
			_mods.Remove(mod);
			NotifyStatChanged();
		}
		
		private void NotifyStatChanged()
		{
			if (OnStatChanged != null)
			{
				OnStatChanged(this);
			}
		}
	}
}