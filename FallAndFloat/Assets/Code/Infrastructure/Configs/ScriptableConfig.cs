using UnityEngine;

namespace Infrastructure.Configs
{
	public class ScriptableConfig<TConfig> : ScriptableObject where TConfig : struct, IConfig
	{
		[field: SerializeField] public TConfig Data { get; private set; }
		public const string ConfigMenuName = "Fall And Float/Configs";
		public const string ConfigFileNamePrefix = "config_";
	}
}