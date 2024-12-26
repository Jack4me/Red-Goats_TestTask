using CodeBase.Infrastructure.AssetsManagement;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services.ProductService;
using CodeBase.StaticData;
using CodeBase.UI.Services.Factory;
using CodeBase.UI.Services.Windows;
using Infrastructure.Services;
using UI.Services;

namespace CodeBase.Infrastructure.States
{
    class BootStrapState : IState
    {
        private const string INITIAL = "Initial";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private AllServices _services;

        public BootStrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _stateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _services = services;
            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoader.Load(INITIAL, onLoaded: EnterLoadLevel);
        }

        private void EnterLoadLevel()
        {
            _stateMachine.EnterGeneric<LoadProgressState>();
        }

        private void RegisterStaticData()
        {
            IStaticDataService staticData = new StaticDataService();
            staticData.Load();
            _services.RegisterService<IStaticDataService>(staticData);
        }

        private void RegisterServices()
        {
            RegisterStaticData();
            _services.RegisterService<IProductDataService>(new ProductDataService());
            _services.RegisterService<IInstantiateProvider>(new InstantiateProvider());


            _services.RegisterService<IUIFactory>(new UIFactory(
                _services.GetService<IInstantiateProvider>(),
                _services.GetService<IStaticDataService>()));

            _services.RegisterService<IWindowService>(new WindowService(
                _services.GetService<IUIFactory>()));

            _services.RegisterService<IGameFactory>
            (new GameFactory(
                _services.GetService<IInstantiateProvider>(),
                _services.GetService<IStaticDataService>(),
                _services.GetService<IWindowService>()));
        }


        public void Exit()
        {
        }
    }
}