using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	[CreateAssetMenu(
		fileName = "canvas_scaler_config", menuName = "Fall And Float/Configs/Canvas Scaler", order = 0)]
	public class CanvasScalerConfigSo : ScriptableObject
	{
		public CanvasScaler.ScaleMode UiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
		public Vector2 ReferenceResolution = new(1920, 1080);
		public CanvasScaler.ScreenMatchMode ScreenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
		[Range(0f, 1f)] public float MatchWidthOrHeight = 0.5f;
	}
}