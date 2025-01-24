using UnityEngine;

namespace YolarUtils.AssetManagement
{
	public class ScriptableConfig<T> : ScriptableObject where T : IGameConfig
	{
		protected const string ConfigPath = "Configs/";
		protected const string ConfigNamePrefix = "config_";
		[field: SerializeField] public T Data { get; private set; }
	}

	public interface IGameConfig { }
}