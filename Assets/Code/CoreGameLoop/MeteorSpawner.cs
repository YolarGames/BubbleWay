using System.Collections;
using StaticData;
using TMPro;
using UnityEngine;
using Utils;
using YolarUtils.Extension;

namespace CoreGameLoop
{
	[SelectionBase]
	public class MeteorSpawner : MonoBehaviour
	{
		[SerializeField] private Meteor _meteorPrefab;
		[field: SerializeField] public float SpawnRate { get; set; } = 3f;
		[SerializeField] private TextMeshProUGUI _tutorialText;
		private WaitForSeconds _waitTime;

		private void Awake()
		{
			_waitTime = new WaitForSeconds(SpawnRate);
		}

		private void Start()
		{
			StartCoroutine(FallRoutine());
		}

#if UNITY_EDITOR
		private void OnDrawGizmos()
		{
			Gizmos.color = Color.yellow;
			Gizmos.DrawLine(transform.position.SetX(-5), transform.position.SetX(5));
		}
#endif

		private IEnumerator FallRoutine()
		{
			yield return new WaitForSeconds(7);
			_tutorialText.gameObject.SetActive(false);
			while (true)
			{
				CreateMeteor();
				yield return _waitTime;
			}
		}

		private void CreateMeteor()
		{
			var randomPosition = new Vector3(CameraUtils.GetRandomScreenWidthPosition(), transform.position.y, 0);
			Meteor meteor = Instantiate(_meteorPrefab, randomPosition, Quaternion.identity, transform);
			meteor.Launch(ObjectSizes.GetRandomSize());
		}
	}
}