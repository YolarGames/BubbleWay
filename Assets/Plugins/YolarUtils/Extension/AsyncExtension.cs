using Cysharp.Threading.Tasks;
using PrimeTween;
using UnityEngine;

namespace YolarUtils.Extension
{
	public static class AsyncExtension
	{
		public static async UniTask Show(this CanvasGroup group, bool useUnscaledTime = false, float duration = 0.5f) =>
			await Tween.Alpha(group, 1, duration, Ease.OutCubic, useUnscaledTime: useUnscaledTime);

		public static async UniTask Hide(this CanvasGroup group, bool useUnscaledTime = false, float duration = 0.5f) =>
			await Tween.Alpha(group, 0, duration, Ease.OutCubic, useUnscaledTime: useUnscaledTime);
	}
}