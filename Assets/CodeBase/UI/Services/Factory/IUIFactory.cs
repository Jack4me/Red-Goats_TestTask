using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.UI.Services.Factory {
    public interface IUIFactory : IService {
        void CreateShop( );
        void CreateRoot();
        void  SetShopButton(GameObject gameObject);
    }
}