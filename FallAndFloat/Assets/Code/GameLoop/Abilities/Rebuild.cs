using VContainer;

namespace GameLoop.Abilities
{
	public class Rebuild : Ability
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