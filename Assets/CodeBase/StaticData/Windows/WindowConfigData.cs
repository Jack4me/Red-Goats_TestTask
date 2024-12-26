using System;
using CodeBase.UI.Services.Windows;
using CodeBase.UI.Windows;

namespace CodeBase.StaticData.Windows {
    [Serializable]
    public class WindowConfigData {
        public WindowIdEnum WindowId;
        public WindowBase Prefab;
    }
}