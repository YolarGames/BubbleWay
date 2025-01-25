using StaticData;
using UnityEngine.Scripting;
using YolarUtils.StateMachine;

namespace Infrastructure.StateMachine
{
	public class BootstrapState : IEnterState
	{
		private readonly IGameStateMachine _stateMachine;

		[Preserve]
		public BootstrapState(IGameStateMachine stateMachine) =>
			_stateMachine = stateMachine;

		public void Enter() =>
			GoToMainMenu();

		private void GoToMainMenu() =>
			_stateMachine.Enter<LoadLevelState, string>(Scenes.MainMenu);
	}
}