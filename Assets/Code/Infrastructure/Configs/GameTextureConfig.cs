using System;
using UnityEngine;
using VHierarchy.Libs;

namespace Infrastructure.Configs
{
	[CreateAssetMenu(fileName = "config_game_textures", menuName = "Fall And Float/Configs/Game Textures")]
	public class GameTextureConfigSo : ScriptableConfig<GameTextureConfig> { }

	[Serializable]
	public struct GameTextureConfig : IConfig
	{
		[SerializeField]
		private VUtils.SerializableDictionary<GameSprites, Sprite> _sprites;
	}

	public enum GameSprites
	{
		Bubble,
		Wizard,
		Meteor,
		House,
	}

	public enum GameImages { }
}