using System.Linq;
using Infrastructure;
using Infrastructure.StateMachine;
using StaticData;
using UI;
using UnityEngine;
using VContainer;
using YolarUtils.Extension;
using YolarUtils.StateMachine;

public class HealthUI : MonoBehaviour
{
	[SerializeField] private House[] _houses;
	private IGameStateMachine _stateMachine;

	private void OnEnable() =>
		GameEvents.OnDamage += UpdateHealth;

	private void OnDisable() =>
		GameEvents.OnDamage -= UpdateHealth;

	[Inject]
	private void Construct(IGameStateMachine stateMachine) =>
		_stateMachine = stateMachine;

	private void UpdateHealth()
	{
		House house = _houses.FirstOrDefault(house => !house.IsBurning);

		if (house.IsNull())
			_stateMachine.Enter<LoadLevelState, string>(Scenes.MainMenu);
		else
			house.SetOnFire();
	}
}