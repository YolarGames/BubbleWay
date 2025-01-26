using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class ExitGameButton : MonoBehaviour
	{
		private Button _button;

		private void Awake() =>
			Debug.Assert(TryGetComponent(out _button), "Button component not found");

		private void OnEnable() =>
			_button.onClick.AddListener(ExitGame);

		private void OnDisable() =>
			_button.onClick.RemoveListener(ExitGame);

		private static void ExitGame() =>
			Application.Quit();
	}
}