using UnityEngine;
using Utils;

namespace BubbleSpawner
{
	public class BubbleSpawner : MonoBehaviour
	{
		[SerializeField] private Bubble _bubblePrefab;
		private Bubble _spawnedBubble;

		private void Start()
		{
			InvokeRepeating(nameof(SpawnBubble), 0, 5);
			InvokeRepeating(nameof(ReleaseBubble), 3, 5);
		}

		private void OnEnable()
		{
			BubbleEvents.OnBubbleStartBlow += SpawnBubble;
			BubbleEvents.OnBubbleEndBlow += ReleaseBubble;
		}

		private void OnDisable()
		{
			BubbleEvents.OnBubbleStartBlow -= SpawnBubble;
			BubbleEvents.OnBubbleEndBlow -= ReleaseBubble;
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.green;
			Gizmos.DrawLine(
				from: new Vector3(-StaticData.GetHalfScreenWidth(), transform.position.y),
				to: new Vector3(StaticData.GetHalfScreenWidth(), transform.position.y));
		}

		private void ReleaseBubble() =>
			_spawnedBubble.Release();

		private void SpawnBubble()
		{
			var randomPosition = new Vector3(StaticData.GetRandomScreenWidthPosition(), transform.position.y, 0);
			_spawnedBubble = Instantiate(_bubblePrefab, randomPosition, Quaternion.identity, transform);
			_spawnedBubble.StartGrow();
		}
	}
}