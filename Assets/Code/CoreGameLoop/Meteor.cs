using UnityEngine;

namespace PeopleSpawner
{
	[SelectionBase, RequireComponent(typeof(CircleCollider2D), typeof(Rigidbody2D))]
	public class Meteor : MonoBehaviour
	{
		[SerializeField] private SpriteRenderer _flameRenderer;
		[SerializeField] private SpriteRenderer _meteorRenderer;
		private CircleCollider2D _collider;
		private Rigidbody2D _rigidbody;

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody2D>();
			_collider = GetComponent<CircleCollider2D>();
		}

		public void SetMeteorCaught(Vector2 velocity)
		{
			_collider.enabled = false;
			_flameRenderer.enabled = false;
			_rigidbody.linearVelocity = velocity;
		}

		public void Launch(float size)
		{
			transform.localScale = Vector3.one * size;
			_rigidbody.AddForce(Vector2.down * 1 / size, ForceMode2D.Impulse);
		}
	}
}