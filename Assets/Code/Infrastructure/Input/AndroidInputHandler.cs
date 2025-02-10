using System;
using UnityEngine;
using UnityEngine.Scripting;
using VContainer.Unity;

namespace Infrastructure.Input
{
	[Preserve]
	public class AndroidInputHandler : IInputHandler, ITickable
	{
		public event Action OnBack = delegate { };

		public void Tick()
		{
			if (UnityEngine.Input.GetKeyDown(KeyCode.Escape)
			    || UnityEngine.Input.GetKeyDown(KeyCode.Backspace))
			{
				Debug.Log("Back button pressed");
				OnBack.Invoke();
			}
		}
	}
}