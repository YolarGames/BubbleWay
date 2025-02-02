using Infrastructure;
using TMPro;
using UnityEngine;

namespace UI
{
	public class GameScore : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _text;
		private int _score;

		private void OnEnable() =>
			GameEvents.OnScoreChanged += UpdateScore;

		private void OnDisable() =>
			GameEvents.OnScoreChanged -= UpdateScore;

		private void UpdateScore() =>
			_text.text = _score++.ToString();
	}
}