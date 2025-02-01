using UnityEngine;
using VContainer;

namespace UI
{
	public class CanvasCameraBinder : MonoBehaviour
	{
		private Camera _camera;
		private Canvas _canvas;

		private void Start()
		{
			_canvas.renderMode = RenderMode.ScreenSpaceCamera;
			_canvas.worldCamera = _camera;
		}

#if UNITY_EDITOR
		private void OnValidate()
		{
			if (TryGetComponent(out Canvas canvas))
				canvas.renderMode = RenderMode.ScreenSpaceCamera;
		}
#endif

		[Inject]
		private void Construct(Camera cam)
		{
			_camera = cam;
			_canvas = GetComponent<Canvas>();
		}
	}
}