using System;
using Audio;
using Cysharp.Threading.Tasks;
using StaticData;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
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

		private async void Play()
		{
			PlayFx(_playButton.transform.position);
			_exitButton.interactable = false;

			await UniTask.Delay(TimeSpan.FromSeconds(_popParticles.main.duration));
			_sceneLoader.Load(Scenes.Game);
		}

		private async void Exit()
		{
			PlayFx(_exitButton.transform.position);
			_exitButton.interactable = false;

			await UniTask.Delay(TimeSpan.FromSeconds(_popParticles.main.duration));
			Application.Quit();
		}

		private void PlayFx(Vector3 position)
		{
			_audioSource.PlayOneShot(_popAudioProvider.GetRandom());
			_popParticles.transform.position = position;
			_popParticles.Play();
		}
	}
}