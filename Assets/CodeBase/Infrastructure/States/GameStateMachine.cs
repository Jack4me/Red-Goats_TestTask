﻿using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using CodeBase.UI.Services.Factory;

namespace CodeBase.Infrastructure.States
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _state;
        private IExitableState _activeState;
        public GameStateMachine(SceneLoader sceneLoader, LoadingCurtain curtain, AllServices services)
        {
            _state = new Dictionary<Type, IExitableState>
            {
                [typeof(BootStrapState)] = new BootStrapState(this, sceneLoader, services),

                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, curtain,
                    services.GetService<IGameFactory>(),
                    services.GetService<IUIFactory>()),
                [typeof(LoadProgressState)] = new LoadProgressState(this),
                [typeof(GameNewLoopState)] = new GameNewLoopState(this)
            };
        }
        public void EnterGeneric<TState>() where TState : class, IState
        {
            var state = ChangeState<TState>();
            state.Enter();
        }

        public void EnterGeneric<TState, TLoadScene>(TLoadScene loadScene)
            where TState : class, ILoadLvlState<TLoadScene>
        {
            TState state = ChangeState<TState>();
            state.Enter(loadScene);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();
            TState state = GetState<TState>();
            _activeState = state;
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState
        {
            return _state[typeof(TState)] as TState;
        }
    }
}