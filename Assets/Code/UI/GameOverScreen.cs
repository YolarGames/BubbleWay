using Cysharp.Threading.Tasks;
using Infrastructure;
using Infrastructure.StateMachine;
using StaticData;
using UnityEngine;
using VContainer;
using YolarUtils.Extension;
using YolarUtils.StateMachine;

namespace UI
{
	public class GameOverScreen : MonoBehaviour
	{
		[SerializeField] private CanvasGroup _panel;
		[SerializeField] private CanvasGroup _text;
		private IGameStateMachine _stateMachine;

		private void Awake()
		{
			_panel.alpha = 0;
			_text.alpha = 0;
			_panel.gameObject.SetActive(false);
		}

		[Inject]
		private void Construct(IGameStateMachine stateMachine)
		{
			_stateMachine = stateMachine;
			GameEvents.OnGameOver += Show;
		}

		private async void Show()
		{
			GameEvents.OnGameOver -= Show;

			_panel.gameObject.SetActive(true);

			_text.Show(duration: 3).Forget();
			await _panel.Show(duration: 3);
			_stateMachine.Enter<LoadLevelState, string>(Scenes.MainMenu);
		}
	}
}