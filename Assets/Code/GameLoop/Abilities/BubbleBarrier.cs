using System;
using Cysharp.Threading.Tasks;
using PrimeTween;
using UnityEngine;
using VContainer;

namespace GameLoop.Abilities
{
	public class BubbleBarrier : Ability
	{
		[SerializeField] private SpriteRenderer _view;
		[SerializeField] private float _duration;
		[SerializeField] private float _cooldown;
		private const float BubbleScaleDuration = 0.5f;
		private const float BubbleScale = 6;
		private HealthRemoveNotifier _healthRemoveNotifier;

		private void Awake() =>
			Cleanup();

		protected override void OnDisable()
		{
			base.OnDisable();
			Cleanup();
		}

		public override async void Use()
		{
			UpscaleView();

			_healthRemoveNotifier.IsActive = false;

			await UniTask.Delay(TimeSpan.FromSeconds(_duration),
				cancellationToken: gameObject.GetCancellationTokenOnDestroy());

			Cleanup();
		}

		public override void Cleanup()
		{
			_healthRemoveNotifier.IsActive = true;
			_view.transform.position = Vector3.zero;
		}

		private void UpscaleView() =>
			Tween.Scale(_view.transform, Vector3.one * BubbleScale, BubbleScaleDuration, Ease.OutBounce);

		[Inject]
		private void Construct(HealthRemoveNotifier healthRemoveNotifier) =>
			_healthRemoveNotifier = healthRemoveNotifier;
	}
}