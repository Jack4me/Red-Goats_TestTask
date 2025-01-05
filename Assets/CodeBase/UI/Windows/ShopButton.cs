using CodeBase.Infrastructure.Services;
using CodeBase.UI.Services.Factory;
using UnityEngine;

namespace CodeBase.UI.Windows
{
    public class ShopButton : MonoBehaviour
    {
        private IUIFactory _uiFactory;

        private void Awake()
        {
            _uiFactory =   AllServices.Container.GetService<IUIFactory>();
           
            _uiFactory.SetShopButton(gameObject);
        }
    }
}
