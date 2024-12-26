using System.Collections.Generic;
using Infrastructure.Services;
using Unity.VisualScripting;
using Product = CodeBase.Logic.Card.Product;

namespace CodeBase.Infrastructure.Services.ProductService
{
    public interface IProductDataService : IService
    {
        List<Product> LoadProducts();

    }
}
