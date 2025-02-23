using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;

namespace GameLoop.Abilities
{
	public class BubbleBarrier : Ability
	{
		[SerializeField] private SpriteRenderer _view;
		[SerializeField] private float _duration;
		[SerializeField] private float _cooldown;
		private HealthRemoveNotifier _healthRemoveNotifier;

		private void OnDisable() =>
			Cleanup();

		public override async void Use()
		{
			_healthRemoveNotifier.IsActive = false;
			await UniTask.Delay(TimeSpan.FromSeconds(_duration),
				cancellationToken: gameObject.GetCancellationTokenOnDestroy());

			Cleanup();
		}

		public override void Cleanup() =>
			_healthRemoveNotifier.IsActive = true;

		[Inject]
		private void Construct(HealthRemoveNotifier healthRemoveNotifier) =>
			_healthRemoveNotifier = healthRemoveNotifier;
	}
}