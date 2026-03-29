using Core.Audio;
using Features.Bubbles;
using UnityEngine;
using VContainer;
using YolarUtils.Extension;

namespace Features.Meteors
{
	internal sealed class MeteorSplitting : Meteor
	{
		[SerializeField] private RandomAudioProviderSo _randomCrackSound;
		private bool _isSplit;
		private IAudioService _audioService;
		private IMeteorFactory _meteorFactory;

		public override void Launch(float size, float horizontalForce = 0)
		{
			base.Launch(size, horizontalForce);

			float randomSplitTime = Random.Range(5f, 8f);
			Invoke(nameof(Split), randomSplitTime);
		}

		protected override void SetCaught(Vector2 velocity)
		{
			CancelInvoke(nameof(Split));
			base.SetCaught(velocity);
		}

		[Inject]
		private void Construct(IMeteorFactory meteorFactory, IAudioService audioService)
		{
			_meteorFactory = meteorFactory;
			_audioService = audioService;
		}

		private void Split()
		{
			GetComponentInChildren<Bubble>()?.Pop();
			_audioService.PlayOneShot(_randomCrackSound);
			LaunchSplinters();
			Destroy(gameObject);
		}

		private void LaunchSplinters()
		{
			Vector3 spawnPosition1 = transform.position.OffsetX(0.2f);
			Vector3 spawnPosition2 = transform.position.OffsetX(-0.2f);

			float randomSize1 = Size / Random.Range(2, 3);
			float randomSize2 = Size / Random.Range(2, 3);

			float randomHorizontalForce1 = Random.Range(0.05f, 0.2f);
			float randomHorizontalForce2 = -Random.Range(0.05f, 0.2f);

			Meteor meteor1 = _meteorFactory.Create(MeteorType.Normal, spawnPosition1);
			Meteor meteor2 = _meteorFactory.Create(MeteorType.Normal, spawnPosition2);

			meteor1.Launch(randomSize1, randomHorizontalForce1);
			meteor2.Launch(randomSize2, randomHorizontalForce2);
		}
	}
}