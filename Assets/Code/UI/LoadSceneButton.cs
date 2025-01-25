using StaticData;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using YolarUtils.SceneManagement;

namespace UI
{
	public class LoadSceneButton : MonoBehaviour
	{
		[SerializeField] private Scene _scene;
		private Button _button;
		private ISceneLoader _sceneLoader;

		private void Awake() =>
			Debug.Assert(TryGetComponent(out _button), "Button component not found");

		private void OnEnable() =>
			_button.onClick.AddListener(LoadScene);

		private void OnDisable() =>
			_button.onClick.RemoveListener(LoadScene);

		[Inject]
		private void Construct(ISceneLoader sceneLoader) =>
			_sceneLoader = sceneLoader;

		private void LoadScene() =>
			_sceneLoader.Load(Scenes.GetName(_scene));
	}
}