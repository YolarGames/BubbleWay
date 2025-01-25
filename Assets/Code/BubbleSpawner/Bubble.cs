using System.Collections;
using UnityEngine;

namespace BubbleSpawner
{
	[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
	public class Bubble : MonoBehaviour
	{
		private Coroutine _growRoutine;

		public void StartGrow()
		{
			_growRoutine = StartCoroutine(GrowRoutine());
		}

		public void Release()
		{
			StopCoroutine(_growRoutine);
			LaunchUp();
		}

		private void LaunchUp()
		{
		}

		private IEnumerator GrowRoutine()
		{
			yield break;
		}
	}
}