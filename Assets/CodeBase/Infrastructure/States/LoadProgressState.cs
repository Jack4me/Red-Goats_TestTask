﻿namespace CodeBase.Infrastructure.States
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMachine _gameStateMachine;

        public LoadProgressState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            _gameStateMachine.EnterGeneric<LoadLevelState, string>
                ("Main");
        }

        public void Exit()
        {
        }
    }
}