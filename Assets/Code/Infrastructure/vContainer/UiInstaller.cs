using UnityEngine;
using VContainer;
using YolarUtils.Extension;

namespace Infrastructure.vContainer
{
	public class UiInstaller : MonoInstaller
	{
		[SerializeField] private ParticleSystem _popParticles;
		[SerializeField] private RectTransform _gameScoreText;
		private Camera _camera;

		private void OnEnable() =>
			GameEvents.OnScoreChanged += PlayPopParticles;

		private void OnDisable() =>
			GameEvents.OnScoreChanged -= PlayPopParticles;

		public override void Install(IContainerBuilder builder) { }

		[Inject]
		private void Construct(Camera cam) =>
			_camera = cam;

		private void PlayPopParticles()
		{
			_popParticles.transform.position = _camera.ScreenToWorldPoint(_gameScoreText.transform.position).SetZ(0);
			_popParticles.Play();
		}
	}
}