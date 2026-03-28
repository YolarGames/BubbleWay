using Features.Health;
using VContainer;

namespace Features.Abilities
{
	internal class Rebuild : Ability
	{
		private HealthHouses _healthHouses;

		public override void Use() =>
			_healthHouses.FixOne();

		public override void Cleanup() { }

		[Inject]
		private void Construct(HealthHouses healthHouses) =>
			_healthHouses = healthHouses;
	}
}