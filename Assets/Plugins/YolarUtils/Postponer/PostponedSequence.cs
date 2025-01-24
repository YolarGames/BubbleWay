using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

namespace YolarUtils.Postponer
{
	public class PostponedSequence : IAsyncDisposable
	{
		private readonly List<PostponedTask> _tasks = new() { PostponedTask.Empty() };
		public bool AutoRun { get; }

		public PostponedSequence(bool autoRun = false) =>
			AutoRun = autoRun;

		public async ValueTask DisposeAsync() =>
			await Run().AsValueTask();

		public PostponedSequence Wait(Func<UniTask> task)
		{
			_tasks.Add(new PostponedTask(task));
			return this;
		}

		public PostponedSequence Do(Action action)
		{
			_tasks[^1].OnComplete(action);
			return this;
		}

		public async UniTask Run()
		{
			foreach (PostponedTask task in _tasks)
				await task.Run();

			_tasks.Clear();
		}
	}
}