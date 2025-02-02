using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using YolarUtils.SmartLogger;

namespace YolarUtils.Postponer
{
	public struct Postponer
	{
		private const bool AutoRun = false;

		public static PostponedSequence Sequence() =>
			new();

		public static async UniTask Wait(Func<UniTask> task) =>
			await task();

		public static void LogError(Exception e) =>
			SLogger.Message(LogSenders.Postponer)
				.WithText("Exception inside sequence: " + e)
				.OfType(LogType.Exception)
				.Log();

		private static async UniTask RunSequence(PostponedSequence sequence)
		{
			await UniTask.Yield();
			await sequence.Run();
		}
	}
}