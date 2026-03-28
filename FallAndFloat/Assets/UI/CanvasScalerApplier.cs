using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	[RequireComponent(typeof(CanvasScaler))]
	public class CanvasScalerApplier : MonoBehaviour
	{
		[SerializeField] private CanvasScalerConfigSo _scalerConfig;

		private void Awake() =>
			ApplyConfig();

		private void Reset() =>
			ApplyConfig();

		private void ApplyConfig()
		{
			var canvasScaler = GetComponent<CanvasScaler>();
			canvasScaler.uiScaleMode = _scalerConfig.UiScaleMode;
			canvasScaler.referenceResolution = _scalerConfig.ReferenceResolution;
			canvasScaler.screenMatchMode = _scalerConfig.ScreenMatchMode;
			canvasScaler.matchWidthOrHeight = _scalerConfig.MatchWidthOrHeight;
		}
	}
}