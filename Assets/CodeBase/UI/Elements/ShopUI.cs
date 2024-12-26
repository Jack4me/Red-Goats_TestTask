using System.Collections.Generic;
using CodeBase.Infrastructure.Services.ProductService;
using CodeBase.Logic.Card;
using Infrastructure.Services;
using UnityEngine;
using Product = CodeBase.Logic.Card.Product;

namespace CodeBase.UI.Elements
{
    public class ShopUI : MonoBehaviour
    {
        private IProductDataService _productDataService;

        public Transform subscriptionContainer;
        public Transform boosterContainer;
        public GameObject cardPrefab;

        void Start()
        {
            _productDataService = AllServices.Container.GetService<IProductDataService>();
            CreateProductCards();
        }

        void CreateProductCards()
        {
            List<Product> products = _productDataService.LoadProducts();
            foreach (Product product in products)
            {
                if (product.Category == "Subscription")
                    CreateCard(product, subscriptionContainer);
                else if (product.Category == "Booster")
                    CreateCard(product, boosterContainer);
            }
        }

        void CreateCard(Product product, Transform container)
        {
            GameObject card = Instantiate(cardPrefab, container);
            ProductCard cardScript = card.GetComponent<ProductCard>();
            cardScript.Setup(product);
        }
    }
}