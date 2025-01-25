using BubbleSpawner;
using UnityEngine;

namespace PeopleSpawner
{
	[SelectionBase, RequireComponent(typeof(CircleCollider2D))]
	public class Meteor : MonoBehaviour
	{
		[SerializeField] private SpriteRenderer _flameRenderer;
		[SerializeField] private SpriteRenderer _meteorRenderer;
		private bool _isFalling;
		private float _fallSpeed = 1f;
		private float RotationSpeed => _fallSpeed / 2;

		private void Update()
		{
			if (!_isFalling)
				return;

			transform.position += Vector3.down * (Time.deltaTime * _fallSpeed);
			_meteorRenderer.transform.rotation =
				Quaternion.Euler(0, 0, _meteorRenderer.transform.rotation.eulerAngles.z + RotationSpeed);
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