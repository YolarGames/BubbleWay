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
			GameEvents.OnDamage += UpdateHealth;

		private void OnDisable() =>
			GameEvents.OnDamage -= UpdateHealth;

		private void UpdateHealth()
		{
			House house = _houses.FirstOrDefault(house => !house.IsBurning);

			if (house.IsNull())
				GameEvents.InvokeOnGameOver();
			else
				house.SetOnFire();
		}
	}
}