using System;

namespace StaticData
{
	public static class Scenes
	{
		public const string MainMenu = "scene_mainMenu";
		public const string Game = "scene_game";

		public static string GetName(Scene scene)
		{
			return scene switch
			{
				Scene.MainMenu => MainMenu,
				Scene.Game => Game,
				_ => throw new ArgumentOutOfRangeException(),
			};
		}
	}

	public enum Scene
	{
		MainMenu = 0,
		Game = 1,
	}
}