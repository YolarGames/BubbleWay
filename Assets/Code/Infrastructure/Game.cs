using UnityEngine;

namespace Infrastructure
{
	public static class Game
	{
		public static void Pause(bool pause) =>
			Time.timeScale = pause ? 0 : 1;
	}
}