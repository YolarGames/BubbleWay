using System;
using UnityEngine;

namespace UI.AbilitiesWindow
{
	[Serializable]
	public struct AbilitiesModel
	{
		[field: SerializeField] public Vector2 HidedPosition { get; private set; }
		[field: SerializeField] public Vector2 ShownPosition { get; private set; }
		[field: SerializeField] public float AutoCLoseDelay { get; private set; }
	}
}