using System;
using UnityEngine;

namespace Core.Infrastructure
{
	public static class GameEvents
	{
		public static event Action OnBubbleEndBlow = delegate { };
		public static event Action OnScoreChanged = delegate { };
		public static event Action OnDamage = delegate { };
		public static event Action OnBubblePop = delegate { };
		public static event Action OnGameOver = delegate { };
		public static event Action OnButtonClick = delegate { };
		public static event Action<Vector3> OnBubbleStartBlow = delegate { };

		public static void InvokeOnBubbleBlow(Vector3 screenToWorldPoint) =>
			OnBubbleStartBlow(screenToWorldPoint);

		public static void InvokeOnBubbleEndBlow() =>
			OnBubbleEndBlow();

		public static void InvokeOnScoreChanged() =>
			OnScoreChanged();

		public static void InvokeOnDamage() =>
			OnDamage();

		public static void InvokeOnBubblePop() =>
			OnBubblePop();

		public static void InvokeOnGameOver() =>
			OnGameOver();

		private static void InvokeOnButtonClick()
		{
			OnButtonClick.Invoke();
		}
	}
}