using UnityEngine;

namespace Features.Weather
{
	internal class RainyWeather : Weather
	{
		[SerializeField] private ParticleSystem _rain;
		[SerializeField] private ParticleSystem _clouds;
		[SerializeField] private GameObject _lightning;

		protected override void Apply()
		{
			_rain.Play();
			_clouds.Play();
		}

		protected override void Cleanup()
		{
			_rain.Stop();
			_clouds.Stop();
		}
	}
}