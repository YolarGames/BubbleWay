using Infrastructure;
using TMPro;
using UnityEngine;

namespace UI
{
	public class GameScore : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _text;
		private int _score;

		private void Start() =>
			PlaceScoreInSafeArea();

		private void OnEnable() =>
			GameEvents.OnScoreChanged += UpdateScore;

		private void OnDisable() =>
			GameEvents.OnScoreChanged -= UpdateScore;

		private void PlaceScoreInSafeArea()
		{
			float safeAreaHeightDifference = Screen.safeArea.height - Screen.height;
			((RectTransform)_text.transform).anchoredPosition = new Vector2(150, -150 + safeAreaHeightDifference);
		}

		private void UpdateScore() =>
			_text.text = _score++.ToString();
	}
}