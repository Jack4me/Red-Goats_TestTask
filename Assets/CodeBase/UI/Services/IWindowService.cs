﻿using CodeBase.Infrastructure.Services;
using CodeBase.UI.Services.Windows;
using Infrastructure.Services;

namespace UI.Services {
    public interface IWindowService : IService {
        void OpenWindow(WindowIdEnum windowIdEnum);
    }
}