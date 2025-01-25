using UnityEngine;

namespace PeopleSpawner
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class Person : MonoBehaviour
	{
		private Rigidbody2D _rigidbody;
		private SpriteRenderer _spriteRenderer;

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody2D>();
			_spriteRenderer = GetComponentInChildren<SpriteRenderer>();
		}

		public void SetSprite(Sprite personSprite)
		{
			// _spriteRenderer.sprite = personSprite;
			transform.localScale = Vector3.one * Random.Range(0.3f, 2f);
			_rigidbody.gravityScale *= transform.localScale.x / 2;
		}
	}
}