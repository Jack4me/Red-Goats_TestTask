using System.Collections.Generic;
using System.Linq;
using CodeBase.StaticData.Windows;
using CodeBase.UI.Services.Windows;
using StaticData;
using UnityEngine;

namespace CodeBase.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<WindowIdEnum, WindowConfigData> _windowConfig;

        public void Load()
        {
            _windowConfig = Resources
                .Load<WindowStaticData>("StaticData/WindowsData/WindowStaticData")
                .ConfigsList
                .ToDictionary(x => x.WindowId, x => x);
        }

        public WindowConfigData ForWindow(WindowIdEnum windowId)
        {
            bool tryGetValue = _windowConfig.TryGetValue(windowId, out WindowConfigData windowConfig);
            return tryGetValue ? windowConfig : null;
        }
    }
}