using Infrastructure;
using UnityEngine;
using YolarUtils.Extension;

namespace CoreGameLoop
{
	public class BubbleSpawner : MonoBehaviour
	{
		[SerializeField] private Bubble _bubblePrefab;
		[SerializeField] private Mage _mage;
		private const float SpawnPositionOffset = 0.5f;
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

		public void DestroyAllBubbles() =>
			FindObjectsByType<Bubble>(FindObjectsSortMode.None)
				.ForEach(bubble => bubble.Pop());

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
			
			Vector3 positionWithOffset = spawnPosition.OffsetY(SpawnPositionOffset);
			
			_mage.CastAt(positionWithOffset);
			_spawnedBubble = Instantiate(_bubblePrefab, positionWithOffset, Quaternion.identity, transform);
			_spawnedBubble.StartGrow();
		}
	}
}