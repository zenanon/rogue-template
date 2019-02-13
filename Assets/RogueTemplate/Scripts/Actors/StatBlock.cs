using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{
	[CreateAssetMenu(fileName = "StatBlock", menuName = "RogueTemplate/Actor/Stats/StatBlock")]
	public class StatBlock : ScriptableObject
	{
		public string Name;
		public delegate void OnStatsChangedDelegate(StatBlock block);
		
		public OnStatsChangedDelegate OnStatsChanged { get; set; }
		
		public Stat[] Stats;
		private readonly Dictionary<string, Stat> _statsDict = new Dictionary<string, Stat>();
		private readonly List<StatBlock> _modifiers = new List<StatBlock>();

		private void Awake()
		{
			if (Application.isPlaying)
			{
				foreach (Stat stat in Stats)
				{
					_statsDict[stat.Name] = Instantiate(stat);
				}
			}
		}

		public int GetBaseStatValue(string statName)
		{
			return !_statsDict.ContainsKey(statName) ? 0 : _statsDict[statName].GetValue();
		}

		public int GetTotalModifers(string statName)
		{
			int mods = 0;
			foreach (StatBlock mod in _modifiers)
			{
				mods += mod.GetStatValue(statName);
			}

			return mods;
		}

		public int GetStatValue(string statName)
		{
			return GetBaseStatValue(statName) + GetTotalModifers(statName);
		}

		public void AddModifier(StatBlock mod)
		{
			_modifiers.Add(mod);
			NotifyStatChange();
		}

		public void RemoveModifier(StatBlock mod)
		{
			_modifiers.Remove(mod);
			NotifyStatChange();
		}

		public void ModifyStat(string statName, int amount)
		{
			if (_statsDict.ContainsKey(statName))
			{
				_statsDict[statName].ModifyValue(amount);
				NotifyStatChange();
			}
		}

		private void NotifyStatChange()
		{
			if (OnStatsChanged != null)
			{
				OnStatsChanged(this);
			}
		}
	}
}