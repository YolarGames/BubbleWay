using Audio;
using UnityEngine;

namespace GameLoop
{
	[SelectionBase, RequireComponent(typeof(CircleCollider2D), typeof(Rigidbody2D))]
	public class Meteor : MonoBehaviour
	{
		[SerializeField] private SpriteRenderer _meteorRenderer;
		[SerializeField] private RandomAudioProviderSo _spawnAudioProvider;
		[SerializeField] private AudioSource _audioSource;
		private CircleCollider2D _collider;
		private Rigidbody2D _rigidbody;
		public float Size { get; private set; }

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody2D>();
			_collider = GetComponent<CircleCollider2D>();
		}

		public void SetMeteorCaught(Vector2 velocity)
		{
			_collider.enabled = false;
			_rigidbody.linearVelocity = velocity;
			Destroy(gameObject, 20f);
		}

		public void Launch(float size)
		{
			Size = size;
			_audioSource.PlayOneShot(_spawnAudioProvider.GetRandom());
			transform.localScale = Vector3.one * size;
			_rigidbody.AddForce(Vector2.down * 1 / size, ForceMode2D.Impulse);
			int torqueDirection = Random.Range(0, 2) == 0 ? -1 : 1;
			_rigidbody.AddTorque(torqueDirection / size, ForceMode2D.Impulse);
		}
	}
}