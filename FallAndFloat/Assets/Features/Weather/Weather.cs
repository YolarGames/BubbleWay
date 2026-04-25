using UnityEngine;

namespace Features.Weather
{
	internal abstract class Weather : MonoBehaviour
	{
		private void Awake() =>
			Prepare();

		private void Start() =>
			Apply();

		private void OnDestroy() =>
			Cleanup();

		protected abstract void Prepare();

		protected abstract void Apply();

		protected abstract void Cleanup();
	}
}