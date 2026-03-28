using UnityEngine;

namespace Core.Utils
{
	public class DontDestroyOnLoad : MonoBehaviour
	{
		private void Awake() =>
			DontDestroyOnLoad(gameObject);
	}
}