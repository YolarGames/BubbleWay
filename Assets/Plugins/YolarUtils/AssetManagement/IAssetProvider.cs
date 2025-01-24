using UnityEngine;

namespace YolarUtils.AssetManagement
{
	public interface IAssetProvider
	{
		GameObjectBuilder<T> Load<T>(string assetName) where T : Component;

		T LoadConfig<T>() where T : IGameConfig;
	}
}