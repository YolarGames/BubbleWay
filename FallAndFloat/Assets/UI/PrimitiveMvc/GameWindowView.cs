using System;
using UnityEngine;

namespace UI.PrimitiveMvc
{
	[Serializable]
	public class GameWindowView
	{
		[HideInInspector] public Canvas Canvas;
		[HideInInspector] public CanvasGroup CanvasGroup;
	}
}