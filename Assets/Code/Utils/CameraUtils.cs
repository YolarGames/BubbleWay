using UnityEngine;

namespace Utils
{
	public static class CameraUtils
	{
		private static Camera s_camera;
		public static Camera Camera => s_camera ??= Camera.main;

		public static float GetRandomScreenWidthPosition()
		{
			float halfWidth = GetHalfScreenWidth() - 1f;
			return Random.Range(-halfWidth, halfWidth);
		}

		public static float GetHalfScreenWidth() =>
			Camera.orthographicSize * Camera.aspect;
	}
}