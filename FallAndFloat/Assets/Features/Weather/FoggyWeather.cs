namespace Features.Weather
{
	internal class FoggyWeather : Weather
	{
		protected override void Prepare() =>
			throw new System.NotImplementedException();

		protected override void Apply() { }

		protected override void Cleanup() { }
	}
}