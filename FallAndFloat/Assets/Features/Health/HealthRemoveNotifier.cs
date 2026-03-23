using Core.Audio;
using Core.Infrastructure;
using Core.StaticData;
using UnityEngine;

namespace Features.Health
{
	public class HealthRemoveNotifier : MonoBehaviour
	{
		[SerializeField] private RandomAudioProviderSo _explosionAudioProvider;
		public bool IsActive = true;

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (!IsActive)
				return;

			if (!other.CompareTag(Tags.Meteor))
				return;

			GameEvents.InvokeOnDamage();
			_explosionAudioProvider.PlayOneShot();
		}
	}
}