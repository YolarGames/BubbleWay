using Infrastructure.StateMachine;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using YolarUtils.AssetManagement;
using YolarUtils.SceneManagement;
using YolarUtils.SmartLogger;
using YolarUtils.StateMachine;

namespace Infrastructure
{
	public class ProjectScope : LifetimeScope
	{
		[SerializeField] private GameObject _eventSystemPrefab;
		[SerializeField] private GameObject _cameraPrefab;

		protected override void Configure(IContainerBuilder builder)
		{
			base.Configure(builder);

			SLogger.Message(LogSenders.Application).WithText("Configuring project scope").Log();

			builder.RegisterEntryPoint<GameBootstrapper>();

			CreateNecessaryPrefabs();
			RegisterStateMachine(builder);
			builder.Register<IAssetProvider, AssetProvider>(Lifetime.Singleton);
			builder.Register<ISceneLoader, SceneLoader>(Lifetime.Singleton);
		}

		private void CreateNecessaryPrefabs()
		{
			Instantiate(_eventSystemPrefab);
			Instantiate(_cameraPrefab);
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