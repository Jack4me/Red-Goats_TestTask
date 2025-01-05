using System.Collections.Generic;
using System.Linq;
using CodeBase.Infrastructure.AssetsManagement;
using CodeBase.StaticData;
using Unity.VisualScripting;
using UnityEngine;
using Product = CodeBase.Logic.Card.Product;

namespace CodeBase.Infrastructure.Services.ProductService
{
    public class ProductDataService : IProductDataService
    {

        public List<T> LoadProducts<T>() where T : Product
        {
            TextAsset jsonFile = Resources.Load<TextAsset>(AssetPath.PRODUCTS_PATH);
            if (jsonFile == null)
            {
                Debug.LogError($"Product data file not found at path: {AssetPath.PRODUCTS_PATH}");
                return new List<T>();
            }

            ProductList<T> productList = JsonUtility.FromJson<ProductList<T>>(jsonFile.text);
            string targetType = typeof(T).Name.Replace("Data", "");

            return productList.Products
                .Where(product => product.Type == targetType)
                .Cast<T>()
                .ToList();
        }
    }
    [System.Serializable]
    class ProductList <T> where T : Product
    {
        public List<T> Products;
    }
}
