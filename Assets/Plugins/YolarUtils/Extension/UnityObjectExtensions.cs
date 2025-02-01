using UnityEngine;

namespace YolarUtils.Extension
{
	public static class UnityObjectExtensions
	{
		public static void DontDestroyOnLoad(this Component component)
		{
			Object.DontDestroyOnLoad(component.gameObject);
		}

		public static void DontDestroyOnLoad(this GameObject gameObject)
		{
			Object.DontDestroyOnLoad(gameObject);
		}
	}
}