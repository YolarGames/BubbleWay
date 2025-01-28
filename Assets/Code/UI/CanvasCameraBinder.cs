using UnityEngine;

namespace UI
{
	public class CanvasCameraBinder : MonoBehaviour
	{
		private static Camera s_camera;

		private void Awake()
		{
			s_camera ??= Camera.main;
			var canvas = GetComponent<Canvas>();
			canvas.renderMode = RenderMode.ScreenSpaceCamera;
			canvas.worldCamera = s_camera;
		}

#if UNITY_EDITOR
		private void OnValidate()
		{
			if (TryGetComponent(out Canvas canvas))
				canvas.renderMode = RenderMode.ScreenSpaceCamera;
		}
#endif
	}
}