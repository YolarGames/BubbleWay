using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace YolarUtils.AssetManagement
{
	public struct GameObjectBuilder<T> where T : Component
	{
		private readonly T _prefab;
		private readonly IObjectResolver _resolver;
		private Quaternion _rotation;
		private Transform _parent;
		private Vector3 _position;

		public GameObjectBuilder(T prefab, IObjectResolver objectResolver)
		{
			_prefab = prefab;
			_resolver = objectResolver;
			_rotation = Quaternion.identity;
			_parent = null;
			_position = Vector3.zero;
		}

		public GameObjectBuilder<T> At(Vector3 position)
		{
			_position = position;
			return this;
		}

		public GameObjectBuilder<T> With(Quaternion rotation)
		{
			_rotation = rotation;
			return this;
		}

		public GameObjectBuilder<T> With(Transform parent)
		{
			_parent = parent;
			return this;
		}

		public T Instantiate() =>
			_resolver.Instantiate(_prefab, _position, _rotation, _parent);
	}
}