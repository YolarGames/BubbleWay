using UnityEngine;
using VContainer;
using VContainer.Unity;
using YolarUtils.Extension;

namespace Features.vContainer
{
	public class SceneScope : LifetimeScope
	{
		[SerializeField] private MonoInstaller[] _installers;

		protected override void Configure(IContainerBuilder builder)
		{
			autoInjectGameObjects.Add(gameObject);
			_installers.ForEach(installer => installer.Install(builder));
		}

		[Inject]
		private void Construct(IObjectResolver resolver)
			=> _installers.ForEach(installer => resolver.InjectGameObject(installer.gameObject));
	}
}