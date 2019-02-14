using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{

	[CreateAssetMenu(fileName = "StatMod", menuName = "RogueTemplate/StatMod")]
	public class StatMod : ScriptableObject
	{
		public string statName;
		public float percentAmount;
		public int flatAmount;
	}
}