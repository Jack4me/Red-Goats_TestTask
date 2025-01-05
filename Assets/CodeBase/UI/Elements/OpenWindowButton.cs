using CodeBase.Infrastructure.Services;
using CodeBase.UI.Services.Windows;
using UI.Services;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Elements {
    public class OpenWindowButton : MonoBehaviour {
        public Button ButtonOpen;
        public WindowIdEnum WindowIdEnum;
        private IWindowService _windowService;

        public void Construct(IWindowService windowService)
        {


        }

        private void Awake(){
            _windowService = AllServices.Container.GetService<IWindowService>();

            ButtonOpen.onClick.AddListener(Open);
        }

        private void Open(){
            if (_windowService == null)
            {
                Debug.Log("WIN NULL");
            }
             _windowService.OpenWindow(WindowIdEnum);
        }
        
    }
}