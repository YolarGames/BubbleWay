using System;

namespace StaticData
{
	public static class Scenes
	{
		public const string MainMenu = "scene_mainMenu";
		public const string Game = "scene_game";
		public const string Bootstrap = "scene_bootstrap";

		public static string GetName(Scene scene)
		{
			return scene switch
			{
				Scene.MainMenu => MainMenu,
				Scene.Game => Game,
				Scene.Bootstrap => Bootstrap,
				_ => throw new ArgumentOutOfRangeException(),
			};
		}
	}

	public enum Scene
	{
		MainMenu = 0,
		Game = 1,
		Bootstrap = 2,
	}
}