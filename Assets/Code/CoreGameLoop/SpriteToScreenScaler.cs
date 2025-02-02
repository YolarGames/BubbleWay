using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace CoreGameLoop
{
	[RequireComponent(typeof(SpriteRenderer))]
	public class SpriteToScreenScaler : MonoBehaviour, IStartable
	{
		private Camera _camera;
		private SpriteRenderer _spriteRenderer;
		private float CameraViewWidth => _camera.orthographicSize;
		private float CameraViewHeight => _camera.orthographicSize / _camera.aspect;
		private float SpriteAspect => _spriteRenderer.sprite.bounds.size.x / _spriteRenderer.sprite.bounds.size.y;

		public void Start()
		{
			_spriteRenderer.drawMode = SpriteDrawMode.Sliced;
			_spriteRenderer.size = GetTargetSize();
		}

		[Inject]
		private void Construct(Camera cam)
		{
			_camera = cam;
			_spriteRenderer = GetComponent<SpriteRenderer>();
		}

		private Vector2 GetTargetSize()
		{
			return SpriteAspect > _camera.aspect
				? new Vector2(CameraViewHeight * _camera.aspect, CameraViewHeight)
				: new Vector2(CameraViewWidth, _camera.orthographicSize / SpriteAspect);
		}
	}
}