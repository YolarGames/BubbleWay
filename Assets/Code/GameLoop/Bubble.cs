using System.Collections;
using Audio;
using Infrastructure;
using PrimeTween;
using StaticData;
using UnityEngine;
using YolarUtils.Extension;

namespace GameLoop
{
	[RequireComponent(typeof(CircleCollider2D), typeof(Rigidbody2D))]
	public class Bubble : MonoBehaviour
	{
		[SerializeField] private SpriteRenderer _spriteRenderer;
		[SerializeField] private ParticleSystem _popParticles;
		[SerializeField] private RandomAudioProviderSo _popAudioProvider;
		[SerializeField] private RandomAudioProviderSo _catchAudioProvider;
		[SerializeField] private AudioSource _audioSource;
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

			if (CanConsumeMeteor(meteor))
				ConsumeMeteor(meteor);
			else
				Pop();
		}

		public void Pop()
		{
			StopGrowing();
			_audioSource.PlayOneShot(_popAudioProvider.GetRandom());
			_collider.enabled = false;
			_spriteRenderer.enabled = false;
			_popParticles.Play();
			Destroy(gameObject, _popParticles.main.duration);

			GameEvents.InvokeOnBubblePop();
		}

		public void StartGrow() =>
			_growRoutine = StartCoroutine(GrowRoutine());

		public void Release()
		{
			if (_growRoutine.IsNull())
				return;

			_audioSource.PlayOneShot(_popAudioProvider.GetRandom());
			StopGrowing();
			LaunchUp();
		}

		private void StopGrowing()
		{
			if (_growRoutine.IsNull())
				return;

			StopCoroutine(_growRoutine);
			_growRoutine = null;
		}

		private void ConsumeMeteor(Meteor meteor)
		{
			GameEvents.InvokeOnScoreChanged();
			_audioSource.PlayOneShot(_catchAudioProvider.GetRandom());
			_collider.enabled = false;

			transform.SetParent(meteor.transform);
			meteor.SetMeteorCaught(_rigidbody.linearVelocity);
			Tween.LocalPosition(transform, Vector2.zero, 0.3f, Ease.OutBounce);
		}

		private bool CanConsumeMeteor(Meteor meteor)
		{
			return IsFittingSize(meteor) && _growRoutine.IsNull();
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