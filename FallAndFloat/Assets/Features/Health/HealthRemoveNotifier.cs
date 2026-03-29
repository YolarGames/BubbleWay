using Core.Audio;
using Core.Infrastructure;
using Core.StaticData;
using UnityEngine;
using VContainer;

namespace Features.Health
{
	public class HealthRemoveNotifier : MonoBehaviour
	{
		[SerializeField] private RandomAudioProviderSo _explosionAudioProvider;
		public bool IsActive = true;
		private IAudioService _audioService;

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (!IsActive)
				return;

			if (!other.CompareTag(Tags.Meteor))
				return;

			GameEvents.InvokeOnDamage();
			_audioService.PlayOneShot(_explosionAudioProvider);
		}

		[Inject]
		private void Construct(IAudioService audioService) =>
			_audioService = audioService;
	}
}