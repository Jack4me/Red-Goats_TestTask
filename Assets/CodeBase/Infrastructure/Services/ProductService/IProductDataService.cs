using System.Collections.Generic;
using Product = CodeBase.Logic.Card.Product;

namespace CodeBase.Infrastructure.Services.ProductService
{
    public interface IProductDataService : IService
    {
        List<T> LoadProducts<T>() where T : Product;

    }
}
