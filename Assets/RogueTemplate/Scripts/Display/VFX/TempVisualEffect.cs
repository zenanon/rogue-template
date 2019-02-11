using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueTemplate
{
	public class TempVisualEffect : MonoBehaviour
	{
		public void ShowFor(float duration, Action onComplete)
		{
			StartCoroutine(RemoveAfterTime(duration, onComplete));
		}

		private IEnumerator RemoveAfterTime(float duration, Action onComplete)
		{
			yield return new WaitForSeconds(duration);
			if (onComplete != null)
			{
				onComplete();
			}
			Destroy(gameObject);
		}
	}
}