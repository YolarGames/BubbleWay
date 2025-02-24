using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameLoop.Abilities
{
	public abstract class Ability : MonoBehaviour
	{
		[SerializeField] private Button _button;

		protected virtual void OnEnable() =>
			_button.onClick.AddListener(Use);

		protected virtual void OnDisable() =>
			_button.onClick.RemoveListener(Use);

		public abstract void Use();

		public abstract void Cleanup();
	}
}