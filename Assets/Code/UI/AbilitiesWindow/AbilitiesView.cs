using System;
using UI.PrimitiveMvc;
using UnityEngine;
using UnityEngine.UI;

namespace UI.AbilitiesWindow
{
	[Serializable]
	public class AbilitiesView : GameWindowView
	{
		[SerializeField] private Image _feather;
		[SerializeField] private Button _bubbleBarrierButton;
		[SerializeField] private Button _perfectCatchButton;
		[SerializeField] private Button _rebuildButton;
	}
}