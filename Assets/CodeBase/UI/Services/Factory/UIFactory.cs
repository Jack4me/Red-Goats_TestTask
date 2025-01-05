using System;
using CodeBase.Infrastructure.AssetsManagement;
using CodeBase.StaticData;
using CodeBase.StaticData.Windows;
using CodeBase.UI.Services.Windows;
using CodeBase.UI.Windows;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CodeBase.UI.Services.Factory
{
    class UIFactory : IUIFactory
    {
        public readonly IInstantiateProvider _assets;
        public IStaticDataService _staticData;
        private WindowBase window;
        private Transform _uiRoot;

        private GameObject _shopButton;

        public UIFactory(IInstantiateProvider assets, IStaticDataService staticData)
        {
            _assets = assets;
            _staticData = staticData;
        }

        public void CreateShop()
        {
            WindowConfigData shop = _staticData.ForWindow(WindowIdEnum.Shop);
            window = Object.Instantiate(shop.Prefab, _uiRoot);
            if (_shopButton == null)
            {
                Debug.Log("_shopButton IS NULL)" );
            }
            else
            {
                _shopButton?.SetActive(false);
            }

            window.OnClose += ShowShopButton;
        }

        public void CreateRoot()
        {
            _uiRoot = _assets.Instantiate(AssetPath.UI_ROOT).transform;
        }

        public void SetShopButton(GameObject shopButton)
        {
            _shopButton = shopButton;
        }

        private void ShowShopButton()
        {
            _shopButton?.SetActive(true);
            if (window != null)
            {
                window.OnClose -= ShowShopButton;
            }
        }
    }
}