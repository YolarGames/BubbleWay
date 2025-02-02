using System;
using Cysharp.Threading.Tasks;
using PrimeTween;
using UI;
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
		[SerializeField] private BubbleSpawner _bubbleSpawner;
		[SerializeField] private MeteorSpawner _meteorSpawner;
		[SerializeField] private GameScore _gameScore;
		[SerializeField] private UiInputReader _inputReader;
		private const float AnimationDuration = 0.5f;

		private void Start()
		{
			Debug.Log("Start tutor");
			StartTutorial().Forget();
		}

		private async UniTask StartTutorial()
		{
			await _panel.Show();
			await Show(_meteorsAreFalling, 3);
			BlinkInputArea(5).Forget();
			await Show(_castBubblesFromVillage, 3);
			await Show(_bubbleSize, 3);
			await _panel.Hide();
			_meteorSpawner.StartSpawning();
			gameObject.SetActive(false);
		}

		private static async UniTask Show(CanvasGroup group, float duration)
		{
			await group.Show();
			await UniTask.Delay(TimeSpan.FromSeconds(duration));
			await group.Hide();
		}

		private async UniTask BlinkInputArea(int times)
		{
			for (var i = 0; i < times; i++)
			{
				await Tween.Color(_inputReader.TargetGraphics, Color.green, AnimationDuration, Ease.OutCubic);
				await Tween.Color(_inputReader.TargetGraphics, Color.clear, AnimationDuration, Ease.OutCubic);
			}
		}
	}
}