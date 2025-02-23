using System.Collections;
using StaticData;
using UnityEngine;
using YolarUtils.Extension;
using Random = UnityEngine.Random;

namespace GameLoop
{
	[SelectionBase]
	public class MeteorSpawner : MonoBehaviour
	{
		[SerializeField] private Meteor _meteorPrefab;
		[field: SerializeField] public float SpawnRate { get; set; } = 3f;
		private const float AwayFromBordersGap = 1f;
		private Camera _camera;
		private Coroutine _fallRoutine;

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

		private IEnumerator FallRoutine()
		{
			while (true)
			{
				CreateMeteor();
				yield return new WaitForSeconds(SpawnRate);
			}
		}

		private void CreateMeteor()
		{
			var randomPosition = new Vector3(GetRandomScreenWidthPosition(), transform.position.y, 0);
			Meteor meteor = Instantiate(_meteorPrefab, randomPosition, Quaternion.identity, transform);
			meteor.Launch(ObjectSizes.GetRandomSize());
		}

		private float GetRandomScreenWidthPosition()
		{
			float halfWidth = GetHalfScreenWidth() - AwayFromBordersGap;
			return Random.Range(-halfWidth, halfWidth);
		}

		private float GetHalfScreenWidth() =>
			_camera.orthographicSize * _camera.aspect;
	}
}