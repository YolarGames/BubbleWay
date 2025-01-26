using Infrastructure;
using TMPro;
using UnityEngine;

namespace UI
{
	public class GameScore : MonoBehaviour
	{
		private int _score;
		private TextMeshProUGUI _text;

		private void Awake() =>
			_text = GetComponent<TextMeshProUGUI>();

		private void OnEnable() =>
			GameEvents.OnScoreChanged += UpdateScore;

		private void UpdateScore()
		{
			_score++;
			_text.text = _score.ToString();
		}
	}
}