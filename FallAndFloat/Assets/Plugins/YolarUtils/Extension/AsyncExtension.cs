using Cysharp.Threading.Tasks;
using PrimeTween;
using UnityEngine;

namespace YolarUtils.Extension
{
	public static class AsyncExtension
	{
		public static async UniTask ShowAsync(this CanvasGroup group, bool useUnscaledTime = false,
			float duration = 0.5f) =>
			await ShowTween(group, useUnscaledTime, duration);

		public static async UniTask HideAsync(this CanvasGroup group, bool useUnscaledTime = false,
			float duration = 0.5f) =>
			await HideTween(group, useUnscaledTime, duration);

		public static Tween ShowTween(this CanvasGroup group, bool useUnscaledTime = false,
			float duration = 0.5f) =>
			Tween.Alpha(group, 1, duration, Ease.OutCubic, useUnscaledTime: useUnscaledTime);

		public static Tween HideTween(this CanvasGroup group, bool useUnscaledTime = false,
			float duration = 0.5f) =>
			Tween.Alpha(group, 0, duration, Ease.OutCubic, useUnscaledTime: useUnscaledTime);
	}
}