using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.AssetsManagement {
    public interface IInstantiateProvider : IService{
        GameObject Instantiate(string Path);
    }
}