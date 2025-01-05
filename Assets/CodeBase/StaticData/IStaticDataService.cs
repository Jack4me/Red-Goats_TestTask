using CodeBase.Infrastructure.Services;
using CodeBase.StaticData.Windows;
using CodeBase.UI.Services.Windows;
using StaticData;
using UnityEngine;

namespace CodeBase.StaticData {
    public interface IStaticDataService : IService{
        void Load();
        WindowConfigData ForWindow(WindowIdEnum windowId);
    }
}