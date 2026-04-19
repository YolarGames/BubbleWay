using Core.Audio;
using Core.Infrastructure;
using Core.StaticData;
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
		private IAudioService _audioService;
		private ISceneLoader _sceneLoader;

		private void OnEnable()
		{
			_playButton.onClick.AddListener(Play);
			_exitButton.onClick.AddListener(Exit);
		}

		private void OnDisable()
		{
			_playButton.onClick.RemoveListener(Play);
			_exitButton.onClick.RemoveListener(Exit);
		}

		[Inject]
		private void Construct(ISceneLoader sceneLoader, IAudioService audioService)
		{
			_sceneLoader = sceneLoader;
			_audioService = audioService;
		}

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
			Game.Quit();
		}

		private void PlayFx(Vector3 position)
		{
			_audioService.PlayOneShot(_popAudioProvider);

			if (_popParticles.IsNull())
				return;
			_popParticles.transform.position = position;
			_popParticles.Play();
		}
	}
}