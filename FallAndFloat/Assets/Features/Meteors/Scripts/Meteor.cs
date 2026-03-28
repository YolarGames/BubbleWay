using Core.Audio;
using Core.Infrastructure;
using Core.StaticData;
using Features.Bubbles;
using Features.StaticData;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Features.Meteors
{
	[SelectionBase, RequireComponent(typeof(CircleCollider2D), typeof(Rigidbody2D))]
	internal class Meteor : MonoBehaviour
	{
		[field: SerializeField] public MeteorType MeteorType { get; private set; }
		[SerializeField] private RandomAudioProviderSo _spawnAudioProvider;
		private CircleCollider2D _collider;
		private Rigidbody2D _rigidbody;
		public float Size { get; private set; }

		protected virtual void Awake()
		{
			_rigidbody = GetComponent<Rigidbody2D>();
			_collider = GetComponent<CircleCollider2D>();
		}

		private void OnDestroy() =>
			StopAllCoroutines();

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (IsBubble(other, out Bubble bubble))
				InteractWithBubble(bubble);
		}

		public virtual void Launch(float size, float horizontalForce = 0f)
		{
			_rigidbody.bodyType = RigidbodyType2D.Dynamic;

			SetSize(size);

			AddForce(size, horizontalForce);

			AddTorque(size);
		}

		protected virtual void InteractWithBubble(Bubble bubble)
		{
			if (IsFittingSize(bubble))
			{
				SetCaught(bubble.LinearVelocity);
				bubble.transform.SetParent(transform);
				bubble.SetConsumedMeteorState();
			}
			else
				bubble.Pop();
		}

		protected virtual void SetCaught(Vector2 velocity)
		{
			GameEvents.InvokeOnScoreChanged();
			_collider.enabled = false;
			_rigidbody.linearVelocity = velocity;
			Destroy(gameObject, 20f);
		}

		protected bool IsFittingSize(Bubble bubble)
		{
			float bubbleSize = bubble.Size;

			return bubbleSize < Size + ObjectSizes.Threshold
			       && bubbleSize > Size - ObjectSizes.Threshold;
		}

		private void SetSize(float size)
		{
			Size = size;
			transform.localScale = Vector3.one * size;
		}

		private void AddTorque(float size)
		{
			float torqueDirection = Random.Range(0, 2) == 0 ? -1f : 1f;
			float torqueAmount = Random.Range(0.5f, 2f) / size * torqueDirection;
			_rigidbody.AddTorque(torqueAmount, ForceMode2D.Impulse);
		}

		private void AddForce(float size, float horizontalForce)
		{
			Vector2 forceVector = new Vector2(horizontalForce, -1) / size;
			_rigidbody.AddForce(forceVector, ForceMode2D.Impulse);
		}

		private static bool IsBubble(Collider2D other, out Bubble bubble)
		{
			bubble = null;

			return other.CompareTag(Tags.Bubble)
			       && other.TryGetComponent(out bubble);
		}
	}
}