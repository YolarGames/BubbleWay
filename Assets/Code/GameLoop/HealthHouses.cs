using System.Linq;
using Infrastructure;
using UnityEngine;
using YolarUtils.Extension;
using YolarUtils.StateMachine;

namespace GameLoop
{
	public class HealthHouses : MonoBehaviour
	{
		[SerializeField] private House[] _houses;
		private IGameStateMachine _stateMachine;

		private void OnEnable() =>
			GameEvents.OnDamage += DestroyOne;

		private void OnDisable() =>
			GameEvents.OnDamage -= DestroyOne;

		public void FixOne() =>
			_houses.FirstOrDefault(house => house.IsBurning)
				?.Fix();

		private void DestroyOne()
		{
			House house = _houses.FirstOrDefault(house => !house.IsBurning);

			house?.SetOnFire();

			if (house.IsNull())
				GameEvents.InvokeOnGameOver();
		}
	}
}