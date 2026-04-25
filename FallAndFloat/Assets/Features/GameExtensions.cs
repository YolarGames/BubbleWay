using UnityEngine;

namespace Features
{
	public static class GameExtensions
	{
		public static Color SetAlpha(this Color color, float alpha) =>
			new(color.r, color.g, color.b, alpha);
	}
}