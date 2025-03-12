using System;
using UnityEngine;

namespace UI.AbilitiesWindow
{
	[Serializable]
	public struct AbilitiesModel
	{
		[SerializeField] private Vector2 _hidedPosition;
		[SerializeField] private Vector2 _shownPosition;
	}
}