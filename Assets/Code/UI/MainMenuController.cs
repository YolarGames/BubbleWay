using Audio;
using StaticData;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using YolarUtils.Extension;
using YolarUtils.SceneManagement;

namespace UI
{
	public class MainMenuController : MonoBehaviour
	{
		[SerializeField] private AudioSource _audioSource;
		[SerializeField] private Button _playButton;
		[SerializeField] private Button _exitButton;
		[SerializeField] private RandomAudioProviderSo _popAudioProvider;
		[SerializeField] private ParticleSystem _popParticles;
		private ISceneLoader _sceneLoader;

		private void OnEnable()
		{
			_playButton.onClick.AddListener(Play);
			_exitButton.onClick.AddListener(Exit);
		}

		[Inject]
		private void Construct(ISceneLoader sceneLoader) =>
			_sceneLoader = sceneLoader;

		private void Play()
		{
			PlayFx(_playButton.transform.position);
			_exitButton.interactable = false;
			_sceneLoader.Load(Scenes.Game);
		}

		private void Exit()
		{
			PlayFx(_exitButton.transform.position);
			_exitButton.interactable = false;
			Application.Quit();
		}

		private void PlayFx(Vector3 position)
		{
			_audioSource.PlayOneShot(_popAudioProvider.GetRandom());

			if (_popParticles.IsNull())
				return;
			_popParticles.transform.position = position;
			_popParticles.Play();
		}
	}
}