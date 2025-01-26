using UnityEngine;

namespace UI
{
	public class CanvasCameraBinder : MonoBehaviour
	{
		private void Awake()
		{
			var canvas = GetComponent<Canvas>();
			canvas.worldCamera = Camera.main;
		}
	}
}