using System;
using Features.Meteors;
using Random = UnityEngine.Random;

namespace Features.StaticData
{
	public static class ObjectSizes
	{
		public const float MinSize = 0.5f;
		public const float MaxSize = 2.5f;
		public const float Threshold = 0.25f;

		public static float GetMeteorSize(MeteorType meteorType) =>
			meteorType switch
			{
				MeteorType.Normal => Random.Range(MinSize, MaxSize),
				MeteorType.Fiery => Random.Range(MinSize, MinSize + 1),
				MeteorType.Splitting => Random.Range(MaxSize - 1, MaxSize),
				MeteorType.Icy => Random.Range(MaxSize - 1, MaxSize),
				_ => throw new ArgumentOutOfRangeException(nameof(meteorType), meteorType, null),
			};
	}
}