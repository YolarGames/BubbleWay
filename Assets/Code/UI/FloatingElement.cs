using PrimeTween;
using UnityEngine;

namespace UI
{
	public class FloatingElement : MonoBehaviour
	{
		[SerializeField] private float _targetY = 5;
		[SerializeField] private float _duration = 1;

		private void Start()
		{
			if (transform is RectTransform rectTransform)
				Tween.LocalPositionY(rectTransform, _targetY, _duration, Ease.InOutCubic, cycles: -1, CycleMode.Yoyo);
			else
				Tween.LocalPositionY(transform, _targetY, _duration, Ease.InOutCubic, cycles: -1, CycleMode.Yoyo);
		}
	}
}