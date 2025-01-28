using TMPro;
using UI;
using UnityEngine;

namespace CoreGameLoop
{
	public class GameTutorial : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _castBubblesFromVillageText;
		[SerializeField] private TextMeshProUGUI _castThreeBubbles;
		[SerializeField] private TextMeshProUGUI _tryCatchMeteorInBubbleText;
		[SerializeField] private MeteorSpawner _meteorSpawner;
		[SerializeField] private GameScore _gameScore;
		
	}
}