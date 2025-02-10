using Cysharp.Threading.Tasks;
using PrimeTween;
using UnityEngine;

namespace YolarUtils.SceneManagement
{
	[RequireComponent(typeof(CanvasGroup))]
	public class LoadingScreen : MonoBehaviour
	{
		[SerializeField] private CanvasGroup _canvasGroup;
		private const float Duration = 0.5f;
		private CanvasGroup CanvasGroup => _canvasGroup ??= GetComponent<CanvasGroup>();

		private void Start()
		{
			CanvasGroup.interactable = false;
			DontDestroyOnLoad(gameObject);
		}

		public async UniTask Appear()
		{
			CanvasGroup.blocksRaycasts = true;
			await Tween.Alpha(_canvasGroup, 1, Duration, useUnscaledTime: true)
				.ToYieldInstruction()
				.WithCancellation(this.GetCancellationTokenOnDestroy());
		}

		public async UniTask Fade()
		{
			CanvasGroup.blocksRaycasts = false;
			await Tween.Alpha(_canvasGroup, 0, Duration, useUnscaledTime: true)
				.ToYieldInstruction()
				.WithCancellation(this.GetCancellationTokenOnDestroy());
		}
	}
}