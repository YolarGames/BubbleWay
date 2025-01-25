using UnityEngine.Scripting;
using YolarUtils.Postponer;
using YolarUtils.SceneManagement;
using YolarUtils.StateMachine;

namespace Infrastructure.StateMachine
{
	public class LoadLevelState : IPayloadState<string>
	{
		private readonly IGameStateMachine _gameStateMachine;
		private readonly ISceneLoader _sceneLoader;

		[Preserve]
		public LoadLevelState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader)
		{
			_gameStateMachine = gameStateMachine;
			_sceneLoader = sceneLoader;
		}

		public async void Enter(string payload)
		{
			await Postponer.Sequence(false)
				.Wait(_sceneLoader.LoadingScreen.Appear)
				.Wait(() => _sceneLoader.Load(payload))
				.Wait(_sceneLoader.LoadingScreen.Fade)
				.Do(_gameStateMachine.Enter<GameLoopState>)
				.Run();
		}
	}
}