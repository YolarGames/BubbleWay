using UnityEngine;

namespace Infrastructure
{
	public static class Game
	{
		public static void Pause(bool pause) =>
			Time.timeScale = pause ? 0.1f : 1;

		public static void Quit()
		{
#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
#else
 			Application.Quit();
#endif
		}
	}
}