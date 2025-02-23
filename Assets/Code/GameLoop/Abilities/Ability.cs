using UnityEngine;

namespace GameLoop.Abilities
{
	public abstract class Ability : MonoBehaviour
	{
		public abstract void Use();

		public abstract void Cleanup();
	}
}