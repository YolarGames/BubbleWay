using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Features.SpriteBehaviours
{
	[CreateAssetMenu(fileName = "game-sprite-config", menuName = "Fall And Float/Configs/Game Sprites")]
	public class GameSpritesConfigSo : ScriptableObject
	{
		[SerializeField] private GameSpritesConfigElement[] _sprites;
		private Dictionary<SpriteId, Sprite> _map;

		public Sprite Get(SpriteId spriteId)
		{
			_map ??= InitMap(_sprites);

			return _map[spriteId];
		}

		private static Dictionary<SpriteId, Sprite> InitMap(GameSpritesConfigElement[] sprites) =>
			sprites.ToDictionary(configElement => configElement.SpriteId, configElement => configElement.Sprite);

		[Serializable]
		private struct GameSpritesConfigElement
		{
			public SpriteId SpriteId;
			public Sprite Sprite;
		}
	}

	public enum SpriteId
	{
		Bubble = 0,
		Meteor = 1,
		Wizard = 2,
		MeteorSplitting = 3,
		IceShell1 = 5,
		IceShell2 = 6,
		IceShell3 = 7,
		IceShell4 = 8,
		IceShell5 = 9,
		House1 = 10,
		House2 = 11,
		House3 = 12,
		House4 = 13,
		House5 = 14,
		Cloud1 = 15,
		Cloud2 = 16,
		Cloud3 = 17,
	}
}