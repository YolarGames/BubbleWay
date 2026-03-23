using Infrastructure.Input;
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

namespace Infrastructure.vContainer
{
	public class ProjectScope : LifetimeScope
	{
		[SerializeField] private GameObject _inGameDebugConsolePrefab;
		[SerializeField] private Camera _cameraPrefab;
		[SerializeField] private EventSystem _eventSystemPrefab;

		protected override void Configure(IContainerBuilder builder)
		{
			Instantiate(_inGameDebugConsolePrefab).DontDestroyOnLoad();

			SLogger.Message(LogSenders.Application).WithText("Configuring project scope").Log();

			builder.RegisterEntryPoint<GameBootstrapper>();

			RegisterCamera(builder);
			RegisterStateMachine(builder);
			builder.Register<IAssetProvider, AssetProvider>(Lifetime.Singleton);
			builder.Register<ISceneLoader, SceneLoader>(Lifetime.Singleton);
			builder.RegisterComponentInNewPrefab(_eventSystemPrefab, Lifetime.Singleton).DontDestroyOnLoad();
			builder.Register<InputHandler>(Lifetime.Singleton).AsImplementedInterfaces();
		}

		private void RegisterEventSystem(IContainerBuilder builder)
		{
			EventSystem eventSystem = Instantiate(_eventSystemPrefab);
			eventSystem.DontDestroyOnLoad();
			builder.RegisterComponent(eventSystem);
		}

		private void RegisterCamera(IContainerBuilder builder)
		{
			Camera cam = Instantiate(_cameraPrefab);
			cam.DontDestroyOnLoad();
			builder.RegisterComponent(cam);
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