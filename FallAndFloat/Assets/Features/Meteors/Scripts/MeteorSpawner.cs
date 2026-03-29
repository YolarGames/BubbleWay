using System;
using System.Collections;
using Core.Audio;
using Features.StaticData;
using UnityEngine;
using VContainer;
using YolarUtils.Extension;
using Random = UnityEngine.Random;

namespace Features.Meteors
{
	[SelectionBase]
	public class MeteorSpawner : MonoBehaviour
	{
		[SerializeField] private AudioClip _spawnClip;
		[field: SerializeField] public float SpawnRate { get; set; } = 3f;
		private const float AwayFromBordersGap = 1f;
		private Camera _camera;
		private Coroutine _fallRoutine;
		private IAudioService _audioService;
		private IMeteorFactory _meteorFactory;
		private float HalfScreenWidth => _camera.orthographicSize * _camera.aspect;
		private float RandomPositionX
		{
			get
			{
				float halfWidth = HalfScreenWidth - AwayFromBordersGap;
				return Random.Range(-halfWidth, halfWidth);
			}
		}

		private void Awake() =>
			_camera = Camera.main;

		private void Start() =>
			StartSpawning();

#if UNITY_EDITOR
		private void OnDrawGizmos()
		{
			Gizmos.color = Color.yellow;
			Gizmos.DrawLine(transform.position.SetX(-5), transform.position.SetX(5));
		}
#endif

		public void StartSpawning() =>
			_fallRoutine = StartCoroutine(FallRoutine());

		public void StopSpawning()
		{
			if (_fallRoutine.NotNull())
				StopCoroutine(_fallRoutine);
		}

		public void DestroyAllMeteors() =>
			FindObjectsByType<Meteor>(FindObjectsSortMode.None).ForEach(meteor => Destroy(meteor.gameObject));

		[Inject]
		private void Construct(IMeteorFactory meteorFactory, IAudioService audioService)
		{
			_meteorFactory = meteorFactory;
			_audioService = audioService;
		}

		private IEnumerator FallRoutine()
		{
			while (Application.isPlaying)
			{
				CreateMeteor();
				yield return new WaitForSeconds(SpawnRate);
			}
		}

		private void CreateMeteor()
		{
			var randomPosition = new Vector2(RandomPositionX, transform.position.y);
			MeteorType meteorType = GetMeteorType();
			float meteorSize = ObjectSizes.GetMeteorSize(meteorType);
			Meteor meteor = _meteorFactory.Create(meteorType, randomPosition);

			_audioService.PlayOneShot(_spawnClip);
			meteor.Launch(meteorSize);
		}

		private static MeteorType GetMeteorType()
		{
			Array enumValues = Enum.GetValues(typeof(MeteorType));
			int randomValue = Random.Range(0, enumValues.Length);

			return (MeteorType)enumValues.GetValue(randomValue);
		}
	}
}