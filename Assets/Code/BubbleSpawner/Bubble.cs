using System.Collections;
using Audio;
using PeopleSpawner;
using PrimeTween;
using StaticData;
using UnityEngine;
using YolarUtils.Extension;

namespace BubbleSpawner
{
	[RequireComponent(typeof(CircleCollider2D), typeof(Rigidbody2D))]
	public class Bubble : MonoBehaviour
	{
		[SerializeField] private SpriteRenderer _spriteRenderer;
		[SerializeField] private ParticleSystem _popParticles;
		[SerializeField] private RandomAudioProviderSo _popAudioProvider;
		[SerializeField] private RandomAudioProviderSo _catchAudioProvider;
		private CircleCollider2D _collider;
		private Coroutine _growRoutine;
		private Rigidbody2D _rigidbody;

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody2D>();
			_collider = GetComponent<CircleCollider2D>();
		}

		private void Start() =>
			transform.localScale = Vector3.one * ObjectSizes.MinSize;

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (!other.TryGetComponent(out Meteor meteor))
				return;

			if (!IsFittingSize(meteor) || _growRoutine.NotNull())
			{
				Pop();
				return;
			}

			GrabMeteor(meteor);
		}

		public void StartGrow() =>
			_growRoutine = StartCoroutine(GrowRoutine());

		public void Release()
		{
			StopGrowing();
			LaunchUp();
		}

		private void StopGrowing()
		{
			if (!_growRoutine.NotNull())
				return;

			StopCoroutine(_growRoutine);
			_growRoutine = null;
		}

		private void GrabMeteor(Meteor meteor)
		{
			AudioSource.PlayClipAtPoint(_catchAudioProvider.GetRandom(), transform.position);
			_collider.enabled = false;
			meteor.transform.SetParent(transform);
			meteor.SetMeteorCaught(_rigidbody.linearVelocity);
			Tween.LocalPosition(meteor.transform, new Vector3(0, 0.2f), 0.1f, Ease.InBounce);
		}

		private void Pop()
		{
			StopGrowing();
			AudioSource.PlayClipAtPoint(_popAudioProvider.GetRandom(), transform.position);
			_spriteRenderer.enabled = false;
			_popParticles.Play();
			Destroy(gameObject, _popParticles.main.duration);
		}

		private bool IsFittingSize(Meteor component)
		{
			float bubbleSize = transform.localScale.x;
			float meteorSize = component.transform.localScale.x;
			return bubbleSize < meteorSize + ObjectSizes.Threshold && bubbleSize > meteorSize - ObjectSizes.Threshold;
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
			transform.localScale = Mathf.Min(newScale.x, ObjectSizes.MaxSize) * Vector3.one;
		}
	}
}