using CoreGameLoop;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Infrastructure
{
	public class GameSceneScope : LifetimeScope
	{
		[SerializeField] private MeteorSpawner _meteorSpawner;

		protected override void Configure(IContainerBuilder builder)
		{
			base.Configure(builder);
			builder.RegisterEntryPoint<GameTutorial>();
			builder.RegisterBuildCallback(_ => _meteorSpawner.StartSpawning());
		}
	}
}