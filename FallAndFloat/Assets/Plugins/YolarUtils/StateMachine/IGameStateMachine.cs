namespace YolarUtils.StateMachine
{
	public interface IGameStateMachine
	{
		void RegisterState<TState>(TState state) where TState : class, IGameState;

		void Enter<TState>() where TState : class, IEnterState;

		void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>;
	}
}