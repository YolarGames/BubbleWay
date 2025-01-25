using System.Collections;
using UnityEngine;
using Utils;

namespace PeopleSpawner
{
	[SelectionBase]
	public class MeteorSpawner : MonoBehaviour
	{
		[SerializeField] private Meteor _meteorPrefab;
		[field: SerializeField] public float SpawnRate { get; set; } = 3f;
		private WaitForSeconds _waitTime;

		private void Awake()
		{
			_waitTime = new WaitForSeconds(SpawnRate);
		}

		private void Start()
		{
			StartCoroutine(FallRoutine());
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawLine(
				from: new Vector3(-StaticData.GetHalfScreenWidth(), transform.position.y),
				to: new Vector3(StaticData.GetHalfScreenWidth(), transform.position.y));
		}

		private IEnumerator FallRoutine()
		{
			while (true)
			{
				CreateMeteor();
				yield return _waitTime;
			}
		}

		private void CreateMeteor()
		{
			var randomPosition = new Vector3(StaticData.GetRandomScreenWidthPosition(), transform.position.y, 0);
			Meteor meteor = Instantiate(_meteorPrefab, randomPosition, Quaternion.identity, transform);
			meteor.Launch(StaticData.GetRandomSize());
		}
	}
}