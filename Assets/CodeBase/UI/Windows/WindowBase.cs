using System;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Windows {
    public class WindowBase : MonoBehaviour {
        public Button CloseButton;
        public event Action OnClose;

        private void Awake() => OnAwake();

        protected virtual void OnAwake() 
        {
            CloseButton.onClick.AddListener(() =>
            {
                OnClose?.Invoke(); 
                Destroy(gameObject); 
            });
        }        
       
        private void Start(){
            Initialize();
            SubscribeUpdate();
        }

        private void OnDestroy(){
            CleanUp();
        }


        protected virtual void Initialize(){
        }

        protected virtual void SubscribeUpdate(){
        }

        protected virtual void CleanUp(){
        }
    }
}