using Infrastructure;
using UnityEngine;
using YolarUtils.Extension;

namespace CoreGameLoop
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
		
#if UNITY_EDITOR
		private void OnDrawGizmos()
		{
			Gizmos.color = Color.green;
			Gizmos.DrawLine(transform.position.SetX(-5), transform.position.SetX(5));
		}
#endif

		private void ReleaseBubble()
		{
			if (_spawnedBubble.NotNull())
			{
				_spawnedBubble.Release();
				_spawnedBubble = null;
			}
		}

		private void SpawnBubble(Vector3 spawnPosition)
		{
			if (_spawnedBubble.NotNull())
				return;

			_spawnedBubble = Instantiate(_bubblePrefab, spawnPosition, Quaternion.identity, transform);
			_spawnedBubble.StartGrow();
		}
	}
}