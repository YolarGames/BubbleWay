using Infrastructure.StateMachine;
using VContainer;
using VContainer.Unity;
using YolarUtils.StateMachine;

namespace Infrastructure
{
	public class ProjectScope : LifetimeScope
	{
		protected override void Configure(IContainerBuilder builder)
		{
			base.Configure(builder);
			RegisterStateMachine(builder);
		}

		private static void RegisterStateMachine(IContainerBuilder builder)
		{
			builder.Register<GameStateMachine>(Lifetime.Singleton);
			builder.Register<IGameState, BootstrapState>(Lifetime.Scoped);
			builder.Register<IGameState, LoadLevelState>(Lifetime.Scoped);
			builder.Register<IGameState, GameLoopState>(Lifetime.Scoped);
		}
	}
}