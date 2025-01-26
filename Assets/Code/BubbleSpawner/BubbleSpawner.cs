using Infrastructure;
using UnityEngine;
using YolarUtils.Extension;

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

		private void ReleaseBubble()
		{
			if (_spawnedBubble.NotNull())
				_spawnedBubble.Release();
		}

		private void SpawnBubble(Vector3 spawnPosition)
		{
			_spawnedBubble = Instantiate(_bubblePrefab, spawnPosition, Quaternion.identity, transform);
			_spawnedBubble.StartGrow();
		}
	}
}