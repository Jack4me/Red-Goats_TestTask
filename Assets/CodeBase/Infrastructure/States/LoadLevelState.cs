using CodeBase.Infrastructure.Factory;
using CodeBase.StaticData;
using CodeBase.UI.Services.Factory;
using Infrastructure;
using StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class LoadLevelState : ILoadLvlState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;
        private readonly IGameFactory _gameFactory;
        private readonly IStaticDataService _staticDataService;
        private IUIFactory _uiFactory;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain curtain,
            IGameFactory gameFactory,
            IUIFactory uiFactory)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
            _gameFactory = gameFactory;
            _uiFactory = uiFactory;
        }

        public void Enter(string sceneName)
        {
            _curtain.Show();
            _gameFactory.CleanUp();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
            _curtain.Hide();
        }

        private void OnLoaded()
        {
            InitUIRoot();
            InitHud();
            _gameStateMachine.EnterGeneric<GameNewLoopState>();
        }

        private void InitUIRoot()
        {
            _uiFactory.CreateRoot();
        }
        private void InitHud()
        {
            _gameFactory.CreateHud();
        }
    }
}