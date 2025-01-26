using Audio;
using Infrastructure;
using StaticData;
using UnityEngine;

namespace CoreGameLoop
{
	public class HealthRemoveNotifier : MonoBehaviour
	{
		[SerializeField] private RandomAudioProviderSo _explosionAudioProvider;
		[SerializeField] private AudioSource _audioSource;

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.CompareTag(Tags.Meteor))
			{
				GameEvents.InvokeOnDamage();
				_audioSource.PlayOneShot(_explosionAudioProvider.GetRandom());
			}
		}
	}
}