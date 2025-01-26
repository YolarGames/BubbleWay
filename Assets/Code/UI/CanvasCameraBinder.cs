using UnityEngine;
using Utils;

namespace UI
{
	public class CanvasCameraBinder : MonoBehaviour
	{
		private void Awake()
		{
			var canvas = GetComponent<Canvas>();
			canvas.worldCamera = CameraUtils.Camera;
		}
	}
}