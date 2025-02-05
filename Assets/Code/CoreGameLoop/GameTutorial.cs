using System;
using Cysharp.Threading.Tasks;
using Infrastructure;
using UnityEngine;
using YolarUtils.Extension;

namespace CoreGameLoop
{
	public class GameTutorial : MonoBehaviour
	{
		[SerializeField] private CanvasGroup _panel;
		[SerializeField] private CanvasGroup _meteorsAreFalling;
		[SerializeField] private CanvasGroup _castBubblesFromVillage;
		[SerializeField] private CanvasGroup _bubbleSize;
		[SerializeField] private CanvasGroup _pressAndHold;
		private const string TutorialBoolKey = "Tutorial";

		private void Awake()
		{
			if (TutorialFinished())
				gameObject.SetActive(false);
		}

		private void Start() =>
			StartTutorial().Forget();

		private static bool TutorialFinished() =>
			PlayerPrefs.GetInt(TutorialBoolKey, 0) == 1;

		private static void SetTutorialFinished() =>
			PlayerPrefs.SetInt(TutorialBoolKey, 1);

		private async UniTask StartTutorial()
		{
			Game.Pause(true);

			await _panel.Show(true);
			await Show(_meteorsAreFalling, 3, true);
			await Show(_castBubblesFromVillage, 3, true);
			await _panel.Hide(true);

			gameObject.SetActive(false);
			GameEvents.OnBubblePop += OnBubblePop;

			Game.Pause(false);
		}

		private async void OnBubblePop()
		{
			Game.Pause(true);
			GameEvents.OnBubblePop -= OnBubblePop;
			gameObject.SetActive(true);

			await _panel.Show(true);
			await Show(_bubbleSize, 3, true);
			await Show(_pressAndHold, 3, true);
			await _panel.Hide(true);

			gameObject.SetActive(false);
			Game.Pause(false);
			SetTutorialFinished();
		}

		private static async UniTask Show(CanvasGroup group, float duration, bool useUnscaledTime = false)
		{
			await group.Show(useUnscaledTime);
			await UniTask.Delay(TimeSpan.FromSeconds(duration), useUnscaledTime);
			await group.Hide(useUnscaledTime);
		}
	}
}