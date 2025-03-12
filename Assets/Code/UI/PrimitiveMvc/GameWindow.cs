using Cysharp.Threading.Tasks;
using PrimeTween;
using UnityEngine;

namespace UI.PrimitiveMvc
{
	[RequireComponent(typeof(Canvas), typeof(CanvasGroup))]
	public abstract class GameWindow<TModel, TView> : MonoBehaviour where TModel : struct where TView : GameWindowView
	{
		[SerializeField] protected TModel Model;
		[SerializeField] protected TView View;
		private const float ShowHideDuration = 0.5f;

		private void Awake()
		{
			View.Canvas = GetComponent<Canvas>();
			View.CanvasGroup = GetComponent<CanvasGroup>();
		}

		public virtual UniTask Open()
		{
			return Tween.Alpha(View.CanvasGroup, 1, ShowHideDuration)
				.OnComplete(() => { View.Canvas.enabled = false; })
				.WithCancellation(destroyCancellationToken);
		}

		public virtual UniTask Close()
		{
			View.Canvas.enabled = true;
			return Tween.Alpha(View.CanvasGroup, 0, ShowHideDuration)
				.WithCancellation(destroyCancellationToken);
		}
	}
}