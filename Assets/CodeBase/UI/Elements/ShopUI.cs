using System.Collections.Generic;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.ProductService;
using CodeBase.Logic.Card;
using UnityEngine;
using Product = CodeBase.Logic.Card.Product;

namespace CodeBase.UI.Elements
{
    public class ShopUI : MonoBehaviour
    {
        private IProductDataService _productDataService;

        public Transform subscriptionContainer;
        public Transform boosterContainer;
        public GameObject subscriptionCardPrefab;
        public GameObject boosterCardPrefab;

        void Start()
        {
            _productDataService = AllServices.Container.GetService<IProductDataService>();
            CreateProductCards();
        }

        void CreateProductCards()
        {
            
            
            List<SubscriptionData> subscriptions = _productDataService.LoadProducts<SubscriptionData>();
            foreach (SubscriptionData subscription in subscriptions)
                CreateCard(subscription, subscriptionContainer, subscriptionCardPrefab);

            List<BoosterData> boosters = _productDataService.LoadProducts<BoosterData>();
            foreach (BoosterData booster in boosters)
                CreateCard(booster, boosterContainer, boosterCardPrefab);
        }
        
        void CreateCard(Product product, Transform container, GameObject cardPrefab)
        {
            GameObject card = Instantiate(cardPrefab, container);
            ProductCard cardScript = card.GetComponent<ProductCard>();
           
            product.SetupCard(cardScript);
            
            
        }
    }
}