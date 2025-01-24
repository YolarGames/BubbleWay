using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace YolarUtils.Postponer
{
	public readonly struct PostponedTask
	{
		public static PostponedTask Empty() =>
			new(() => UniTask.CompletedTask);

		private readonly Func<UniTask> _task;
		private readonly List<Action> _onComplete;

		public PostponedTask(Func<UniTask> task)
		{
			_onComplete = new List<Action>();
			_task = task;
		}

		public async UniTask Run()
		{
			try
			{
				await _task();
			}
			catch (Exception e)
			{
				Postponer.LogError(e);
			}

			Complete();
		}

		public void OnComplete(Action action) =>
			_onComplete.Add(action);

		private void Complete()
		{
			foreach (Action action in _onComplete)
				try
				{
					action?.Invoke();
				}
				catch (Exception e)
				{
					Postponer.LogError(e);
				}
		}
	}
}