using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{

	public class RLBaseItem
	{
		public string Name { get; private set; }
		public int DisplayType { get; private set; }

		public delegate void OnBehavioursChangedDelegate(RLBaseItem item);

		private OnBehavioursChangedDelegate _onBehavioursChanged;
		public OnBehavioursChangedDelegate OnBehavioursChanged
		{
			get { return _onBehavioursChanged; }
			set { _onBehavioursChanged = value; }
		}

		private List<RLItemBehaviour> _itemBehaviours = new List<RLItemBehaviour>();
		public List<RLItemBehaviour> ItemBehaviours
		{
			get { return _itemBehaviours; }
		}
		
		public RLBaseItem(string name, int displayType)
		{
			Name = name;
			DisplayType = displayType;
		}

		public void AddBehaviour(RLItemBehaviour behaviour)
		{
			ItemBehaviours.Add(behaviour);
			if (OnBehavioursChanged != null)
			{
				OnBehavioursChanged(this);
			}
		}
	}
}