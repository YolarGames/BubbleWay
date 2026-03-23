using PrimeTween;
using TMPro;
using UnityEngine;

namespace UI
{
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class TextGradient : MonoBehaviour
	{
		[SerializeField] private Color _from;
		[SerializeField] private Color _to;
		[SerializeField] private float _duration = 0.5f;
		private TextMeshProUGUI _text;

		private void Awake() =>
			_text = GetComponent<TextMeshProUGUI>();

		private void Start() =>
			Tween.Color(_text, _from, _to, _duration, Ease.InOutCubic, cycles: -1, CycleMode.Yoyo);
	}
}