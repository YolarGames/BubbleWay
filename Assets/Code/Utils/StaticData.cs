using UnityEngine;

namespace Utils
{
	public static class StaticData
	{
		private const float MinSize = 1f;
		public const float MaxSize = 2.5f;
		public const float Threshold = 0.25f;
		private static Camera s_camera;
		public static Camera Camera => s_camera ??= Camera.main;

		public static float GetRandomSize() =>
			Random.Range(MinSize, MaxSize);

		public static float GetRandomScreenWidthPosition()
		{
			float halfWidth = GetHalfScreenWidth();
			return Random.Range(-halfWidth, halfWidth);
		}

		public static float GetHalfScreenWidth() =>
			Camera.orthographicSize * Camera.aspect;
	}
}