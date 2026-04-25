using PrimeTween;
using UnityEngine;
using YolarUtils.Extension;

namespace Features.Weather
{
	internal class RainyWeather : Weather
	{
		[SerializeField] private ParticleSystem _rain;
		[SerializeField] private SpriteRenderer[] _clouds;
		private readonly Color _cloudColor = new(0.6f, 0.6f, 0.6f, 0.8f);

		protected override void Prepare() =>
			_clouds.ForEach(Deactivate);

		protected override void Apply()
		{
			ShowClouds();
			_rain.Play();
		}

		protected override void Cleanup()
		{
			HideClouds();
			StopRain();
		}

		private void StopRain()
		{
			ParticleSystem.EmissionModule emission = _rain.emission;
			var tweenSettings = new TweenSettings(2f, Ease.Linear);
			Tween.Custom(emission.rateOverTime.constant, 0, tweenSettings, OnValueChange);

			return;

			void OnValueChange(float newValue) =>
				emission.rateOverTime = new ParticleSystem.MinMaxCurve(newValue);
		}

		private void HideClouds()
		{
			foreach (SpriteRenderer cloud in _clouds)
				Tween.Alpha(cloud, 0, duration: 2f, Ease.Linear)
					.OnComplete(() => Deactivate(cloud));
		}

		private void ShowClouds()
		{
			foreach (SpriteRenderer cloud in _clouds)
			{
				cloud.color = _cloudColor.SetAlpha(0);
				Activate(cloud);
				Tween.Alpha(cloud, _cloudColor.a, duration: 2f, Ease.Linear);
			}

			Invoke(nameof(Cleanup), 2f);
		}

		private static void Deactivate(SpriteRenderer cloud) =>
			cloud.gameObject.SetActive(false);

		private static void Activate(SpriteRenderer cloud) =>
			cloud.gameObject.SetActive(true);
	}
}