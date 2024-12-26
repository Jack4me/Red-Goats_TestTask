using CodeBase.Infrastructure.Services;
using Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory {
    public interface IGameFactory : IService {

        GameObject CreateHud();
        void CleanUp();
    }
}