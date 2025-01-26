using UnityEngine;
using Utils;

namespace UI
{
	public class CanvasCameraBinder : MonoBehaviour
	{
		private void Start()
		{
			Debug.Assert(TryGetComponent(out Canvas canvas), "Canvas component not found");
			canvas.worldCamera = CameraUtils.Camera;
		}
	}
}