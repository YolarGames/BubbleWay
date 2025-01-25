using BubbleSpawner;
using UnityEngine;

namespace PeopleSpawner
{
	[SelectionBase, RequireComponent(typeof(CircleCollider2D))]
	public class Meteor : MonoBehaviour
	{
		[SerializeField] private SpriteRenderer _flameRenderer;
		private bool _isFalling;
		private float _fallSpeed = 1f;

		private void Update()
		{
			if (!_isFalling)
				return;

			transform.position += Vector3.down * (Time.deltaTime * _fallSpeed);
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.gameObject.TryGetComponent(out Bubble bubble))
				_flameRenderer.enabled = false;
		}

		public void Launch(float size)
		{
			_isFalling = true;
			_fallSpeed /= size;
			transform.localScale = Vector3.one * size;
		}
	}
}