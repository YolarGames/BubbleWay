using Infrastructure;
using UnityEngine;
using Utils;

namespace BubbleSpawner
{
	public class BubbleSpawner : MonoBehaviour
	{
		[SerializeField] private Bubble _bubblePrefab;
		private Bubble _spawnedBubble;

		private void OnEnable()
		{
			GameEvents.OnBubbleStartBlow += SpawnBubble;
			GameEvents.OnBubbleEndBlow += ReleaseBubble;
		}

		private void OnDisable()
		{
			GameEvents.OnBubbleStartBlow -= SpawnBubble;
			GameEvents.OnBubbleEndBlow -= ReleaseBubble;
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

		private void SpawnBubble(Vector3 spawnPosition)
		{
			_spawnedBubble = Instantiate(_bubblePrefab, spawnPosition, Quaternion.identity, transform);
			_spawnedBubble.StartGrow();
		}
	}
}