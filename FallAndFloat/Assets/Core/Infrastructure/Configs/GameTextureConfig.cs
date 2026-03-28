using System;
using System.Collections.Generic;
using UnityEngine;
using YolarUtils.Extension;

namespace Core.Infrastructure.Configs
{
	[CreateAssetMenu(fileName = "game-textures-config", menuName = "Fall And Float/Configs/Game Textures")]
	public class GameTextureConfigSo : ScriptableObject
	{
		[SerializeField] private GameSprite[] _sprites;
		private static Dictionary<GameSpriteId, Sprite> s_spriteIdToSpriteMap;

		private Sprite Get(GameSpriteId spriteId)
		{
			MapIfNull(s_spriteIdToSpriteMap, _sprites);

			return s_spriteIdToSpriteMap[spriteId];
		}

		private void MapIfNull(Dictionary<GameSpriteId, Sprite> spriteIdToSpriteMap, GameSprite[] sprites)
		{
			if (spriteIdToSpriteMap.IsNull() || spriteIdToSpriteMap.Count == 0)
				spriteIdToSpriteMap ??= new Dictionary<GameSpriteId, Sprite>();

			foreach (GameSprite gameSprite in sprites)
				spriteIdToSpriteMap.Add(gameSprite.SpriteId, gameSprite.Sprite);
		}

		[Serializable]
		private struct GameSprite
		{
			public GameSpriteId SpriteId;
			public Sprite Sprite;
		}
	}
	
	public enum GameSpriteId
	{
		Bubble,
		Wizard,
		Meteor,
		House,
	}
}