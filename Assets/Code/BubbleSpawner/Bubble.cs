using System.Collections;
using UnityEngine;
using Utils;

namespace BubbleSpawner
{
	[RequireComponent(typeof(CircleCollider2D))]
	public class Bubble : MonoBehaviour
	{
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
			transform.localScale = Vector3.one * 0.2f;
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
				SetSize(Time.deltaTime / 3f);
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