using Infrastructure.StateMachine;
using UnityEngine;
using UnityEngine.EventSystems;
using VContainer;
using VContainer.Unity;
using YolarUtils.AssetManagement;
using YolarUtils.Extension;
using YolarUtils.SceneManagement;
using YolarUtils.SmartLogger;
using YolarUtils.StateMachine;

namespace Infrastructure
{
	public class ProjectScope : LifetimeScope
	{
#if DEBUG
		[SerializeField] private GameObject _inGameDebugConsolePrefab;
#endif
		[SerializeField] private Camera _cameraPrefab;
		[SerializeField] private EventSystem _eventSystemPrefab;

		protected override void Configure(IContainerBuilder builder)
		{
#if DEBUG
			Instantiate(_inGameDebugConsolePrefab).DontDestroyOnLoad();
#endif

			base.Configure(builder);

			SLogger.Message(LogSenders.Application).WithText("Configuring project scope").Log();

			builder.RegisterEntryPoint<GameBootstrapper>();

			RegisterStateMachine(builder);
			builder.Register<IAssetProvider, AssetProvider>(Lifetime.Singleton);
			builder.Register<ISceneLoader, SceneLoader>(Lifetime.Singleton);
			builder.RegisterComponentInNewPrefab(_cameraPrefab, Lifetime.Singleton).DontDestroyOnLoad();
			builder.RegisterComponentInNewPrefab(_eventSystemPrefab, Lifetime.Singleton).DontDestroyOnLoad();
		}

		private static void RegisterStateMachine(IContainerBuilder builder)
		{
			builder.Register<IGameStateMachine, GameStateMachine>(Lifetime.Singleton);
			builder.Register<IGameState, BootstrapState>(Lifetime.Scoped);
			builder.Register<IGameState, LoadLevelState>(Lifetime.Scoped);
			builder.Register<IGameState, GameLoopState>(Lifetime.Scoped);
		}
	}
}