using System.Linq;
using Infrastructure;
using UI;
using UnityEngine;
using YolarUtils.Extension;

public class HealthUI : MonoBehaviour
{
	[SerializeField] private House[] _houses;

	private void OnEnable() =>
		GameEvents.OnDamage += UpdateHealth;

	private void UpdateHealth()
	{
		House house = _houses.FirstOrDefault(house => house.IsBurning);

		if (house.IsNull()) { }
		else
			house.SetOnFire();
	}
}