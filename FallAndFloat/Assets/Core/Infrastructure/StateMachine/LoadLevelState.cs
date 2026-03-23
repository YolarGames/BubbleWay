using UnityEngine.Scripting;
using YolarUtils.Postponer;
using YolarUtils.SceneManagement;
using YolarUtils.StateMachine;

namespace Core.Infrastructure.StateMachine
{
	public class LoadLevelState : IPayloadState<string>
	{
		private readonly IGameStateMachine _gameStateMachine;
		private readonly ISceneLoader _sceneLoader;
		private readonly LoadingScreen _loadingScreen;

		[Preserve]
		public LoadLevelState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader, LoadingScreen loadingScreen)
		{
			_gameStateMachine = gameStateMachine;
			_sceneLoader = sceneLoader;
			_loadingScreen = loadingScreen;
		}

		public async void Enter(string payload) =>
			await Postponer.Sequence()
				.Wait(_loadingScreen.Appear)
				.Wait(() => _sceneLoader.Load(payload))
				.Wait(_loadingScreen.Fade)
				.Do(_gameStateMachine.Enter<GameLoopState>)
				.Run();
	}
}