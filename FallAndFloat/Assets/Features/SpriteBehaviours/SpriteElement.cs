using UnityEngine;
using VContainer;

namespace Features.SpriteBehaviours
{
	[RequireComponent(typeof(SpriteRenderer))]
	public class SpriteElement : MonoBehaviour
	{
		[SerializeField] private SpriteId _spriteId;
		private GameSpritesConfigSo _spritesConfigSo;
		private SpriteRenderer _spriteRenderer;

		private void Start() =>
			_spriteRenderer.sprite = _spritesConfigSo.Get(_spriteId);

		[Inject]
		private void Construct(GameSpritesConfigSo spritesConfigSo)
		{
			_spritesConfigSo = spritesConfigSo;
			_spriteRenderer = GetComponent<SpriteRenderer>();
		}
	}
}