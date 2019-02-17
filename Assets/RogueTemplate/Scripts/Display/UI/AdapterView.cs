using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RogueTemplate
{
	public class AdapterView<T, V>: MonoBehaviour where V: ViewHolder<T>
	{
		public V viewHolderPrefab;
		public Transform container;

		private List<V> _viewHolders = new List<V>();

		public virtual V CreateViewHolder()
		{
			V viewHolder = Object.Instantiate(viewHolderPrefab, container);
			_viewHolders.Add(viewHolder);
			return viewHolder;
		}

		public virtual void BindViewHolder(V viewHolder, T data)
		{
			viewHolder.BindData(data);
		}

		public void BindDataList(List<T> dataList)
		{
			for (int i = 0; i < _viewHolders.Count; i++)
			{
				_viewHolders[i].BindData(dataList[i]);
			}
			for (int i = _viewHolders.Count; i < dataList.Count(); i++)
			{
				BindViewHolder(CreateViewHolder(), dataList[i]);
			}
			
			for (int i = dataList.Count; i < _viewHolders.Count; i++)
			{
				Object.Destroy(_viewHolders[i].gameObject);
			}
			_viewHolders.RemoveRange(dataList.Count, _viewHolders.Count - dataList.Count);
		}
	}
}