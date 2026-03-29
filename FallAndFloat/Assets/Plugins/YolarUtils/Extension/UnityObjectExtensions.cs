using UnityEngine;

namespace YolarUtils.Extension
{
	public static class UnityObjectExtensions
	{
		public static void DontDestroyOnLoad(this Component component) =>
			Object.DontDestroyOnLoad(component.gameObject);

		public static void DontDestroyOnLoad(this GameObject gameObject) =>
			Object.DontDestroyOnLoad(gameObject);

		public static void DeactivateGo(this Component component) =>
			component.gameObject.SetActive(false);

		public static void DestroyGo(this Component component) =>
			Object.Destroy(component.gameObject);
	}
}