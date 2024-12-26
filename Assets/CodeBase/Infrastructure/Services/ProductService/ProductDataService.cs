using System.Collections.Generic;
using CodeBase.Infrastructure.AssetsManagement;
using CodeBase.StaticData;
using Unity.VisualScripting;
using UnityEngine;
using Product = CodeBase.Logic.Card.Product;

namespace CodeBase.Infrastructure.Services.ProductService
{
    public class ProductDataService : IProductDataService
    {

        public List<Product> LoadProducts()
        {
            TextAsset jsonFile = Resources.Load<TextAsset>(AssetPath.PRODUCTS_PATH);
            if (jsonFile == null)
            {
                Debug.LogError($"Product data file not found at path: {AssetPath.PRODUCTS_PATH}");
                return new List<Product>();
            }

            ProductList productList = JsonUtility.FromJson<ProductList>(jsonFile.text);
            return productList.Products;
        }
    }
    [System.Serializable]
    class ProductList
    {
        public List<Product> Products;
    }
}
