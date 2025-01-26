using System;
using System.Collections.Generic;

namespace YolarUtils.Extension
{
	public static class EnumerableExtensions
	{
		public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
		{
			foreach (T item in enumerable)
				action(item);
		}
		
		public static T GetRandom<T>(this T[] array) =>
			array[UnityEngine.Random.Range(0, array.Length)];
	}
}