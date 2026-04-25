namespace Features.Weather
{
	internal class BlizzardWeather : Weather
	{
		protected override void Prepare() =>
			throw new System.NotImplementedException();

		protected override void Apply() { }

		protected override void Cleanup() { }
	}
}