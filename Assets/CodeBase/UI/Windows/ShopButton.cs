using CodeBase.UI.Services.Factory;
using Infrastructure.Services;
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
