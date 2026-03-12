using Audio;
using Infrastructure;
using StaticData;
using UnityEngine;

namespace GameLoop
{
	public class HealthRemoveNotifier : MonoBehaviour
	{
		[SerializeField] private RandomAudioProviderSo _explosionAudioProvider;
		[SerializeField] private AudioSource _audioSource;
		public bool IsActive = true;

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (!IsActive)
				return;

			if (!other.CompareTag(Tags.Meteor))
				return;
			
			GameEvents.InvokeOnDamage();
			_audioSource.PlayOneShot(_explosionAudioProvider.GetRandom());
		}
	}
}