using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace UI
{
	public class CanvasCameraBinder : MonoBehaviour, IStartable
	{
		private Camera _camera;
		private Canvas _canvas;

#if UNITY_EDITOR
		private void OnValidate()
		{
			if (TryGetComponent(out Canvas canvas))
				canvas.renderMode = RenderMode.ScreenSpaceCamera;
		}
#endif

		public void Start()
		{
			_canvas.renderMode = RenderMode.ScreenSpaceCamera;
			_canvas.worldCamera = _camera;
		}

		[Inject]
		private void Construct(Camera cam)
		{
			_camera = cam;
			_canvas = GetComponent<Canvas>();
		}
	}
}