using Infrastructure;
using Infrastructure.Input;
using Infrastructure.StateMachine;
using PrimeTween;
using StaticData;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using YolarUtils.Extension;
using YolarUtils.StateMachine;

namespace UI
{
	[RequireComponent(typeof(CanvasGroup))]
	public class PauseMenu : MonoBehaviour
	{
		[SerializeField] private Button _continueButton;
		[SerializeField] private Button _exitToMainMenuButton;
		private bool _isShown;
		private CanvasGroup _canvasGroup;
		private IGameStateMachine _stateMachine;
		private IInputHandler _inputHandler;
		private Tween _showHideTween;

		private void OnEnable()
		{
			_continueButton.onClick.AddListener(ToggleMenu);
			_exitToMainMenuButton.onClick.AddListener(GoToMainMenu);
			_inputHandler.OnBack += ToggleMenu;
		}

		private void OnDisable()
		{
			_continueButton.onClick.RemoveListener(ToggleMenu);
			_exitToMainMenuButton.onClick.RemoveListener(GoToMainMenu);
			_inputHandler.OnBack -= ToggleMenu;
		}

		private void ToggleMenu()
		{
			if (_showHideTween.isAlive)
				_showHideTween.Stop();

			if (_isShown)
			{
				_showHideTween = _canvasGroup.HideTween(useUnscaledTime: true);
				_isShown = false;
				Game.Pause(false);
			}
			else
			{
				_showHideTween = _canvasGroup.ShowTween(useUnscaledTime: true);
				_isShown = true;
				Game.Pause(true);
			}
		}

		private void GoToMainMenu() =>
			_stateMachine.Enter<LoadLevelState, string>(Scenes.MainMenu);

		[Inject]
		private void Construct(IInputHandler inputHandler, IGameStateMachine stateMachine)
		{
			_canvasGroup = GetComponent<CanvasGroup>();
			_inputHandler = inputHandler;
			_stateMachine = stateMachine;
		}
	}
}