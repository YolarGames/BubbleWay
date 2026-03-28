using Core.Infrastructure;
using Core.Infrastructure.Configs;
using Core.Infrastructure.Input;
using Core.Infrastructure.StateMachine;
using Features.Meteors;
using UnityEngine;
using UnityEngine.EventSystems;
using VContainer;
using VContainer.Unity;
using YolarUtils.Extension;
using YolarUtils.SceneManagement;
using YolarUtils.SmartLogger;
using YolarUtils.StateMachine;

namespace Features.vContainer
{
	public class ProjectScope : LifetimeScope
	{
		[SerializeField] private GameObject _inGameDebugConsolePrefab;
		[SerializeField] private Camera _cameraPrefab;
		[SerializeField] private EventSystem _eventSystemPrefab;
		[SerializeField] private MeteorConfigSo _meteorConfigSo;
		[SerializeField] private GameTextureConfigSo _gameTextureConfigSo;
		[SerializeField] private LoadingScreen _loadingScreenPrefab;

		protected override void Configure(IContainerBuilder builder)
		{
			Instantiate(_inGameDebugConsolePrefab).DontDestroyOnLoad();

			SLogger.Message(LogSenders.Application).WithText("Configuring project scope").Log();

			builder.RegisterEntryPoint<GameBootstrapper>();

			RegisterCamera(builder);
			RegisterStateMachine(builder);
			RegisterConfigs(builder);
			builder.Register<ISceneLoader, SceneLoader>(Lifetime.Singleton);
			builder.Register<IMeteorFactory, MeteorFactory>(Lifetime.Singleton);
			builder.Register<IInputHandler, ITickable, InputHandler>(Lifetime.Singleton);
			builder.RegisterComponentInNewPrefab(_eventSystemPrefab, Lifetime.Singleton).DontDestroyOnLoad();
			builder.RegisterComponentInNewPrefab(_loadingScreenPrefab, Lifetime.Singleton).DontDestroyOnLoad();
		}

		private void RegisterConfigs(IContainerBuilder builder)
		{
			builder.RegisterInstance(_meteorConfigSo);
			builder.RegisterInstance(_gameTextureConfigSo);
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