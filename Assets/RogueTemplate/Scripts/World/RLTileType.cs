using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{
	[CreateAssetMenu(fileName = "RLTileType", menuName = "RogueTemplate/RLTileType")]
	public class RLTileType : ScriptableObject
	{
		[SerializeField] private int _displayType;
		[SerializeField] private bool _blocksVision;
		[SerializeField] private bool _blocksMovement;

		public int DisplayType
		{
			get { return _displayType; }
		}

		public bool BlocksVision
		{
			get { return _blocksVision; }
		}

		public bool BlocksMovement
		{
			get { return _blocksMovement; }
		}
	}
}