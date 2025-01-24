namespace YolarUtils.StateMachine
{
	public interface IGameState { }

	public interface IEnterState : IGameState
	{
		void Enter();
	}

	public interface IExitState : IGameState
	{
		void Exit();
	}

	public interface IPayloadState<in T> : IGameState
	{
		void Enter(T payload);
	}
}