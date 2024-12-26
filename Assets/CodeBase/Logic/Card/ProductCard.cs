using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Logic.Card
{
    public class ProductCard : MonoBehaviour
    {
        public TextMeshProUGUI NameText;
        public TextMeshProUGUI PriceText;
        public Image Icon;

        public void Setup(Product product)
        {
            NameText.text = product.Name;
            PriceText.text = $"${product.Price:F2}";
            Icon.sprite = Resources.Load<Sprite>(product.IconPath);
        }
    }
}
