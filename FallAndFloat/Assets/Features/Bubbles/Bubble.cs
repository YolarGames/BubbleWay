using System.Collections;
using Core.Audio;
using Core.Infrastructure;
using Features.StaticData;
using PrimeTween;
using UnityEngine;
using YolarUtils.Extension;

namespace Features.Bubbles
{
	[RequireComponent(typeof(CircleCollider2D), typeof(Rigidbody2D))]
	internal class Bubble : MonoBehaviour
	{
		[SerializeField] private ParticleSystem _popParticles;
		[SerializeField] private RandomAudioProviderSo _popAudioProvider;
		[SerializeField] private RandomAudioProviderSo _catchAudioProvider;
		private CircleCollider2D _collider;
		private Coroutine _growRoutine;
		private Rigidbody2D _rigidbody;
		public float Size { get; private set; }
		public Vector2 LinearVelocity => Vector2.up / transform.localScale.x;

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody2D>();
			_collider = GetComponent<CircleCollider2D>();
		}

		private void Start() =>
			transform.localScale = Vector3.one * ObjectSizes.MinSize;

		public void Pop()
		{
			StopGrowing();

			_popAudioProvider.PlayOneShot();

			Instantiate(_popParticles, transform.position, Quaternion.identity);

			GameEvents.InvokeOnBubblePop();

			Destroy(gameObject);
		}

		public void StartGrow() =>
			_growRoutine = StartCoroutine(GrowRoutine());

		public void Release()
		{
			if (_growRoutine.IsNull())
				return;

			_popAudioProvider.PlayOneShot();
			StopGrowing();
			LaunchUp();
		}

		public void SetConsumedMeteorState()
		{
			StopGrowing();
			
			_rigidbody.linearVelocity = Vector3.zero;

			_collider.enabled = false;
			_catchAudioProvider.PlayOneShot();
			Tween.LocalPosition(transform, Vector2.zero, 0.3f, Ease.OutBounce);
		}

		private void StopGrowing()
		{
			if (_growRoutine.IsNull())
				return;

			StopCoroutine(_growRoutine);
			_growRoutine = null;
		}

		private void LaunchUp() =>
			_rigidbody.linearVelocity = LinearVelocity;

		private IEnumerator GrowRoutine()
		{
			while (Application.isPlaying)
			{
				SetSize(Time.deltaTime);
				yield return null;
			}
		}

		private void SetSize(float size)
		{
			Vector3 newScale = transform.localScale + Vector3.one * size;
			transform.localScale = Mathf.Min(newScale.x, ObjectSizes.MaxSize) * Vector3.one;
			Size = transform.localScale.x;
		}
	}
}