using System.Collections;
using UnityEngine;
using Utils;

namespace BubbleSpawner
{
	[RequireComponent(typeof(CircleCollider2D))]
	public class Bubble : MonoBehaviour
	{
		[SerializeField] private float _growSpeed = 3f;
		private const float StartSize = 0.5f;
		private bool _isLaunched;
		private Coroutine _growRoutine;
		private float _flySpeed = 1f;

		private void Update()
		{
			if (!_isLaunched)
				return;

			transform.position -= Vector3.down * (Time.deltaTime * _flySpeed);
		}

		public void StartGrow()
		{
			transform.localScale = Vector3.one * StartSize;
			_growRoutine = StartCoroutine(GrowRoutine());
		}

		public void Release()
		{
			StopCoroutine(_growRoutine);
			LaunchUp();
		}

		private void LaunchUp()
		{
			_flySpeed /= transform.localScale.x;
			_isLaunched = true;
		}

		private IEnumerator GrowRoutine()
		{
			while (!_isLaunched)
			{
				SetSize(Time.deltaTime / _growSpeed);
				yield return null;
			}
		}

		private void SetSize(float size)
		{
			Vector3 newScale = transform.localScale + Vector3.one * size;
			transform.localScale = Mathf.Min(newScale.x, StaticData.MaxSize) * Vector3.one;
		}
	}
}