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

		private void Start()
		{
			_canvasGroup.alpha = 0;
			_canvasGroup.interactable = false;
			_canvasGroup.blocksRaycasts = false;
			_continueButton.onClick.AddListener(ToggleMenu);
			_exitToMainMenuButton.onClick.AddListener(GoToMainMenu);
			_inputHandler.OnBack += ToggleMenu;
		}

		private void OnDestroy()
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
				HideScreen();
			else
				ShowScreen();
		}

		private void ShowScreen()
		{
			_isShown = true;
			Game.Pause(true);
			gameObject.SetActive(true);
			_canvasGroup.interactable = true;
			_canvasGroup.blocksRaycasts = true;
			_showHideTween = _canvasGroup.ShowTween(useUnscaledTime: true);
		}

		private void HideScreen()
		{
			_isShown = false;
			Game.Pause(false);
			_canvasGroup.interactable = false;
			_canvasGroup.blocksRaycasts = false;
			_showHideTween = _canvasGroup.HideTween(useUnscaledTime: true)
				.OnComplete(() => gameObject.SetActive(false));
		}

		private void GoToMainMenu()
		{
			Game.Pause(false);
			_stateMachine.Enter<LoadLevelState, string>(Scenes.MainMenu);
		}

		[Inject]
		private void Construct(IInputHandler inputHandler, IGameStateMachine stateMachine)
		{
			_canvasGroup = GetComponent<CanvasGroup>();
			_inputHandler = inputHandler;
			_stateMachine = stateMachine;
		}
	}
}