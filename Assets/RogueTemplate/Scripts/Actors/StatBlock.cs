using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang.Environments;
using UnityEngine;

namespace RogueTemplate
{
	[CreateAssetMenu(fileName = "StatBlock", menuName = "RogueTemplate/Actor/Stats/StatBlock")]
	public class StatBlock : ScriptableObject
	{
		public string statBlockName;
		public delegate void OnStatsChangedDelegate(StatBlock block);
		
		public OnStatsChangedDelegate OnStatsChanged { get; set; }
		
		public Stat[] Stats;
		private readonly Dictionary<string, Stat> _statsDict = new Dictionary<string, Stat>();

		public static StatBlock CreateInstance(StatBlock template, params int[] values)
		{
			StatBlock instance = Instantiate(template);
			if (values.Length != 0 && values.Length != instance.Stats.Length)
			{
				throw new ArgumentException(string.Format("Initial stat values mismatch: expected {0}, found {1}",
					instance.Stats.Length,
					values.Length));
			}

			for (int i = 0; i < instance.Stats.Length; i++)
			{
				instance.Stats[i] = Instantiate(instance.Stats[i]);
				if (i < values.Length)
				{
					instance.Stats[i].SetBaseValue(values[i]);
				}
			}

			foreach (Stat stat in instance.Stats)
			{
				instance._statsDict[stat.statName] = stat;
			}

			return instance;
		}

		public void AddModifier(StatMod mod)
		{
			if (_statsDict.ContainsKey(mod.statName))
			{
				_statsDict[mod.statName].AddModifier(mod);
			}
		}

		public void RemoveModifier(StatMod mod)
		{
			if (_statsDict.ContainsKey(mod.statName))
			{
				_statsDict[mod.statName].RemoveModifier(mod);
			}
		}
	}
}