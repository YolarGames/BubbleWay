using System.Collections.Generic;
using Core.Infrastructure.StateMachine;
using PrimeTween;
using UnityEngine;
using UnityEngine.Scripting;
using VContainer.Unity;
using YolarUtils.Extension;
using YolarUtils.SmartLogger;
using YolarUtils.StateMachine;

namespace Core.Infrastructure
{
	public class GameBootstrapper : IInitializable
	{
		private readonly IEnumerable<IGameState> _gameState;
		private readonly IGameStateMachine _gameStateMachine;

		[Preserve]
		public GameBootstrapper(IGameStateMachine gameStateMachine, IEnumerable<IGameState> gameState)
		{
			_gameStateMachine = gameStateMachine;
			_gameState = gameState;
		}

		public void Initialize()
		{
			SLogger.Message(LogSenders.Application).WithText("Registering game states").Log();

			Application.targetFrameRate = 60;
			PrimeTweenConfig.warnEndValueEqualsCurrent = false;

			_gameState.ForEach(_gameStateMachine.RegisterState);
			_gameStateMachine.Enter<BootstrapState>();
		}
	}
}