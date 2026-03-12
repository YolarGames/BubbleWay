using UnityEngine;

namespace StaticData
{
	public static class ObjectSizes
	{
		public const float MinSize = 0.5f;
		public const float MaxSize = 2.5f;
		public const float Threshold = 0.25f;

		public static float GetRandomSize() =>
			Random.Range(MinSize, MaxSize);
	}
}