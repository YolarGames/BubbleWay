using System;
using System.Collections.Generic;
using YolarUtils.Extension;
using YolarUtils.SmartLogger;
using Object = UnityEngine.Object;

namespace YolarUtils.StateMachine
{
	public abstract class StateMachineBase : IGameStateMachine
	{
		private readonly Dictionary<Type, IGameState> _states = new();
		private IGameState _currentState;

		public void Enter<TState>() where TState : class, IEnterState
		{
			if (IsSameState<TState>())
				return;

			StateMachineLogger.LogEnter(_currentState?.GetType(), typeof(TState));
			var nextState = SwitchState<TState>();
			nextState.Enter();
		}

		public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
		{
			if (IsSameState<TState>())
				return;

			StateMachineLogger.LogEnter(_currentState?.GetType(), typeof(TState), payload);
			var nextState = SwitchState<TState>();
			nextState.Enter(payload);
		}

		public void RegisterState<TState>(TState state) where TState : class, IGameState =>
			_states.Add(state.GetType(), state);

		private TState SwitchState<TState>() where TState : class, IGameState
		{
			var nextState = GetNewState<TState>();

			if (_currentState.NotNull() && _currentState is IExitState exitState)
				exitState.Exit();

			_currentState = nextState;
			return nextState;
		}

		private bool IsSameState<TState>() where TState : class, IGameState =>
			_currentState?.GetType() == typeof(TState);

		private TState GetNewState<TState>() where TState : class, IGameState =>
			_states[typeof(TState)] as TState;

		private static class StateMachineLogger
		{
			public static void LogEnter(Type oldState, Type newState) =>
				SLogger.Message(LogSenders.GameStateMachine)
					.WithText($"Entering {NewState(newState)}. Previous state: {OldState(oldState)}")
					.Log();

			public static void LogEnter(Type oldState, Type newState, object payload)
			{
				string payloadName = payload switch
				{
					Object unityObj => unityObj.name,
					string name => name,
					_ => payload.ToString(),
				};

				SLogger.Message(LogSenders.GameStateMachine)
					.WithText(
						$"Entering {NewState(newState)} with payload {payloadName.White()}. Previous state: {OldState(oldState)}")
					.Log();
			}

			private static string NewState(Type state) =>
				state.Name.White();

			private static string OldState(Type state) =>
				(state != null ? state.Name : "null").White();
		}
	}
}