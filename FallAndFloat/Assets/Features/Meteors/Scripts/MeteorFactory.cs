using System;
using UnityEngine;
using VContainer;
using YolarUtils.Extension;
using Object = UnityEngine.Object;

namespace Features.Meteors
{
	[UnityEngine.Scripting.Preserve]
	internal class MeteorFactory : IMeteorFactory
	{
		private readonly IObjectResolver _resolver;
		private readonly Lazy<Transform> _meteorParent = new(CreateParentObject());
		private readonly MeteorConfigSo _config;

		public MeteorFactory(MeteorConfigSo config, IObjectResolver resolver)
		{
			_config = config;
			_resolver = resolver;
		}

		public Meteor Create(MeteorType type, Vector2 position)
		{
			Meteor prefab = _config.GetPrefabFromMeteorType(type);
			Meteor instance = Object.Instantiate(prefab, position, Quaternion.identity, _meteorParent.Value);

			_resolver.Inject(instance);
			
			return instance;
		}

		private static Transform CreateParentObject()
		{
			var gameObject = new GameObject("meteor-parent");
			gameObject.DontDestroyOnLoad();
			return gameObject.transform;
		}
	}

	internal interface IMeteorFactory
	{
		Meteor Create(MeteorType type, Vector2 position);
	}
}