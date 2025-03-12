using System;
using UI.PrimitiveMvc;
using UnityEngine;
using UnityEngine.UI;

namespace UI.AbilitiesWindow
{
	[Serializable]
	public class AbilitiesView : GameWindowView
	{
		[SerializeField] private Button _openButton;
		[SerializeField] private Button _bubbleBarrierButton;
		[SerializeField] private Button _perfectCatchButton;
		[SerializeField] private Button _rebuildButton;

		public event Action OnButtonClick
		{
			add => _openButton.onClick.AddListener(value.Invoke);
			remove => _openButton.onClick.RemoveListener(value.Invoke);
		}
	}
}