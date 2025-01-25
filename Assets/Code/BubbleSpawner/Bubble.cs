using System.Collections;
using PeopleSpawner;
using PrimeTween;
using UnityEngine;
using Utils;
using YolarUtils.Extension;

namespace BubbleSpawner
{
	[RequireComponent(typeof(CircleCollider2D), typeof(Rigidbody2D))]
	public class Bubble : MonoBehaviour
	{
		[SerializeField] private SpriteRenderer _spriteRenderer;
		[SerializeField] private ParticleSystem _popParticles;
		private const float StartSize = 0.5f;
		private CircleCollider2D _collider;
		private Coroutine _growRoutine;
		private Rigidbody2D _rigidbody;

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody2D>();
			_collider = GetComponent<CircleCollider2D>();
			_collider.enabled = false;
		}

		private void Start() =>
			transform.localScale = Vector3.one * StartSize;

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (!other.TryGetComponent(out Meteor meteor))
				return;

			if (!IsFittingSize(meteor) || _growRoutine.NotNull())
			{
				Pop();
				return;
			}

			_collider.enabled = false;
			meteor.transform.SetParent(transform);
			meteor.SetMeteorCaught(_rigidbody.linearVelocity);
			Tween.LocalPosition(meteor.transform, new Vector3(0, 0.2f), 0.1f, Ease.InBounce);
		}

		public void StartGrow() =>
			_growRoutine = StartCoroutine(GrowRoutine());

		public void Release()
		{
			StopCoroutine(_growRoutine);
			_growRoutine = null;
			_collider.enabled = true;
			LaunchUp();
		}

		private void Pop()
		{
			_collider.enabled = false;
			_spriteRenderer.enabled = false;
			_popParticles.Play();
			Invoke(nameof(Destroy), _popParticles.main.duration);
		}

		private void Destroy()
		{
			Destroy(gameObject);
		}

		private bool IsFittingSize(Meteor component)
		{
			float bubbleSize = transform.localScale.x;
			float meteorSize = component.transform.localScale.x;
			return bubbleSize < meteorSize + StaticData.Threshold && bubbleSize > meteorSize - StaticData.Threshold;
		}

		private void LaunchUp() =>
			_rigidbody.AddForce(Vector2.up * 1 / transform.localScale.x, ForceMode2D.Impulse);

		private IEnumerator GrowRoutine()
		{
			while (true)
			{
				SetSize(Time.deltaTime);
				yield return null;
			}
		}

		private void SetSize(float size)
		{
			Vector3 newScale = transform.localScale + Vector3.one * size;
			transform.localScale = Mathf.Min(newScale.x, StaticData.MaxSize) * Vector3.one;
		}
	}
}