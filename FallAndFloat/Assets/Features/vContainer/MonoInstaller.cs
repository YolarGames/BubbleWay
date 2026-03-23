using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Features.vContainer
{
	public abstract class MonoInstaller : MonoBehaviour, IInstaller
	{
		public abstract void Install(IContainerBuilder builder);
	}
}