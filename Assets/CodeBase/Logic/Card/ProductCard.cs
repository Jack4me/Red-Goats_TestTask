using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Logic.Card
{
    public  class ProductCard : MonoBehaviour
    {
        
        public TextMeshProUGUI NameText;
        public TextMeshProUGUI PriceText;
        public Image Icon;
        
      
        // Уникальные элементы для подписки
        public TextMeshProUGUI subscriptionDurationText;
        public TextMeshProUGUI boosterTypeText;
        public void Setup(Product product)
        {
            NameText.text = product.Name;
            PriceText.text = $"${product.Price:F2}";
            Icon.sprite = Resources.Load<Sprite>(product.IconPath);
        }
        public void SetupBooster(BoosterData booster)
        {
            Setup(booster); 
            boosterTypeText.text = $"Type: {booster.BoosterType}";
        }

        public void SetupSubscription(SubscriptionData subscription)
        {
            Setup(subscription); 
            subscriptionDurationText.text = $"Duration: {subscription.DurationMonths} months";
        }
    }
}
