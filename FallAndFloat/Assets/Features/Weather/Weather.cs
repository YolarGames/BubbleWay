using UnityEngine;

namespace Features.Weather
{
	internal abstract class Weather : MonoBehaviour
	{
		private void Awake() =>
			Apply();

		private void OnDestroy() =>
			Cleanup();

		protected abstract void Apply();

		protected abstract void Cleanup();
	}
}