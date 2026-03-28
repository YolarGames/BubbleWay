using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	[CreateAssetMenu(
		fileName = "canvas_scaler_config", menuName = "Fall And Float/Configs/Canvas Scaler", order = 0)]
	public class CanvasScalerConfigSo : ScriptableObject
	{
		public CanvasScaler.ScaleMode UiScaleMode;
		public Vector2 ReferenceResolution;
		public CanvasScaler.ScreenMatchMode ScreenMatchMode;
		[Range(0f, 1f)] public float MatchWidthOrHeight;
	}
}