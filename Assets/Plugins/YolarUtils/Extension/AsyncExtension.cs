using Cysharp.Threading.Tasks;
using PrimeTween;
using UnityEngine;

namespace YolarUtils.Extension
{
	public static class AsyncExtension
	{
		public static async UniTask Show(this CanvasGroup group) =>
			await Tween.Alpha(group, 1, 0.5f, Ease.OutCubic);

		public static async UniTask Hide(this CanvasGroup group) =>
			await Tween.Alpha(group, 0, 0.5f, Ease.OutCubic);
	}
}