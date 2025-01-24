using System.IO;
using UnityEngine;
using VContainer;
using YolarUtils.SmartLogger;
using Object = UnityEngine.Object;

namespace YolarUtils.AssetManagement
{
	public class AssetProvider : IAssetProvider
	{
		private const string AssetsPath = "Assets/";
		private const string ConfigsPath = "Configs/";
		private readonly IObjectResolver _resolver;

		[UnityEngine.Scripting.Preserve]
		public AssetProvider(IObjectResolver resolver) =>
			_resolver = resolver;

		GameObjectBuilder<T> IAssetProvider.Load<T>(string assetName) =>
			new(Load<T>(AssetsPath + assetName), _resolver);

		public T LoadConfig<T>() where T : IGameConfig =>
			Load<ScriptableConfig<T>>(ConfigsPath).Data;

		private static T Load<T>(string path) where T : class
		{
			SLogger.Message(LogSenders.Assets)
				.WithText($"Loading asset {typeof(T).Name} from path: {path}")
				.Log();

			Object[] instances = LoadAllOfType<T>(path);
			Debug.Assert(instances.Length == 1, $"Multiple instances of {typeof(T).Name} found.");
			return instances[0] as T;
		}

		private static Object[] LoadAllOfType<T>(string path) where T : class
		{
			Object[] configInstances = Resources.LoadAll(path, typeof(T));
			if (configInstances.Length <= 0)
				throw new FileNotFoundException($"{typeof(T).Name} not found.");
			return configInstances;
		}
	}
}