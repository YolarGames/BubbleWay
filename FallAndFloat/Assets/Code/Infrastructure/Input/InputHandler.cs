using System;
using UnityEngine;
using UnityEngine.Scripting;
using VContainer.Unity;

namespace Infrastructure.Input
{
	[Preserve]
	public class InputHandler : IInputHandler, ITickable
	{
		public event Action OnBack = delegate { };

		public void Tick()
		{
			if (UnityEngine.Input.GetKeyDown(KeyCode.Escape)
			    || UnityEngine.Input.GetKeyDown(KeyCode.Backspace))
				OnBack.Invoke();
		}
	}
}