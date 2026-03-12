using UnityEngine;
using VContainer;
using YolarUtils.Extension;

namespace Infrastructure.vContainer
{
	public class UiInstaller : MonoInstaller
	{
		[SerializeField] private ParticleSystem _popParticles;
		[SerializeField] private RectTransform _gameScoreText;
		[SerializeField] private Canvas[] _sortingOrder;
		private Camera _camera;

		private void Start()
		{
			for (var i = 0; i < _sortingOrder.Length; i++)
				_sortingOrder[i].sortingOrder = i;
		}

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