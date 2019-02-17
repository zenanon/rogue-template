using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{
	public abstract class ViewHolder<T> : MonoBehaviour
	{
		public abstract void BindData(T data);
	}
}