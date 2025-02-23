using Cysharp.Threading.Tasks;
using Infrastructure;
using UnityEngine;
using VContainer;
using YolarUtils.Extension;

namespace GameLoop
{
	public class BubbleSpawner : MonoBehaviour
	{
		[SerializeField] private Bubble _bubblePrefab;
		[SerializeField] private Mage _mage;
		private const float SpawnHeight = 1.5f;
		private Bubble _spawnedBubble;
		private Camera _camera;

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

		public async void BlowBubbleAt(float positionX, float size)
		{
			SpawnBubble(new Vector3(positionX, SpawnHeight));
			while (!_spawnedBubble.Size.Approximately(size))
				await UniTask.Yield(gameObject.GetCancellationTokenOnDestroy());
			ReleaseBubble();
		}

		private void DestroyAllBubbles() =>
			FindObjectsByType<Bubble>(FindObjectsSortMode.None)
				.ForEach(bubble => bubble.Pop());

		[Inject]
		private void Construct(Camera cam)
		{
			_camera = cam;
		}

		private void ReleaseBubble()
		{
			if (_spawnedBubble.IsNull())
				return;

			_spawnedBubble.Release();
			_spawnedBubble = null;
		}

		private void SpawnBubble(Vector3 inputPosition)
		{
			if (_spawnedBubble.NotNull())
				return;

			Vector3 spawnPosition = GetSpawnPosition(inputPosition);

			_mage.CastAt(spawnPosition);
			_spawnedBubble = Instantiate(_bubblePrefab, spawnPosition, Quaternion.identity, transform);
			_spawnedBubble.StartGrow();
		}

		private Vector3 GetSpawnPosition(Vector3 inputPosition) =>
			inputPosition.SetY(-_camera.orthographicSize + SpawnHeight);
	}
}