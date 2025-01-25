using UnityEngine;

namespace BubbleSpawner
{
	public class BubbleSpawner : MonoBehaviour
	{
		[SerializeField] private Bubble _bubblePrefab;
		private Bubble _spawnedBubble;

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
			Gizmos.DrawLine(new Vector3(-2.5f, transform.position.y), new Vector3(2.5f, transform.position.y));
		}

		private void ReleaseBubble() =>
			_spawnedBubble.Release();

		private void SpawnBubble() =>
			Instantiate(_bubblePrefab, transform.position, Quaternion.identity, transform)
				.StartGrow();
	}
}