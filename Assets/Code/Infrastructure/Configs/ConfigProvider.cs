using System;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Configs
{
	public interface IConfigProvider
	{
		T GetConfig<T>() where T : struct, IConfig;
	}

	public class ConfigProvider : IConfigProvider
	{
		private const string ConfigsFolderPath = "Configs";
		private Dictionary<Type, IConfig> _savedConfigs;

		public TConfig GetConfig<TConfig>() where TConfig : struct, IConfig
		{
			if (TryGetConfig<TConfig>(out IConfig config))
				return (TConfig)config;

			return RegisterConfig<TConfig>();
		}

		private bool TryGetConfig<TConfig>(out IConfig config) where TConfig : struct, IConfig =>
			_savedConfigs.TryGetValue(typeof(TConfig), out config);

		private TConfig RegisterConfig<TConfig>() where TConfig : struct, IConfig
		{
			var config = LoadSingle<TConfig>();
			_savedConfigs.Add(typeof(TConfig), config);
			return config;
		}

		private static TConfig LoadSingle<TConfig>() where TConfig : struct, IConfig =>
			Resources.LoadAll<ScriptableConfig<TConfig>>(ConfigsFolderPath)[0].Data;
	}
}