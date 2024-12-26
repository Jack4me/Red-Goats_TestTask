using CodeBase.Infrastructure.AssetsManagement;
using CodeBase.StaticData;
using CodeBase.UI.Elements;
using UI.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IInstantiateProvider _instantiate;
        private readonly IWindowService _windowService;


        public GameFactory(IInstantiateProvider instantiate, IStaticDataService staticData, 
            IWindowService windowService)
        {
            _instantiate = instantiate;

            _windowService = windowService;
        }


        public GameObject CreateHud()
        {
            var hud = InstantiateRegister(AssetPath.HUD_PATH);

            foreach (OpenWindowButton openWindowButton in hud.GetComponentsInChildren<OpenWindowButton>())
            {
                openWindowButton.Construct(_windowService);
            }

            return hud;
        }

        public void CleanUp()
        {
        }

        private GameObject InstantiateRegister(string path)
        {
            GameObject gameObject = _instantiate.Instantiate(path);
            return gameObject;
        }
    }
}