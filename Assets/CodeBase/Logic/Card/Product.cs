
namespace CodeBase.Logic.Card
{
    [System.Serializable]
    public abstract class Product
    {
      
        public string Name;
        public float Price;
        public string IconPath;
        public string Type;

        public abstract void SetupCard(ProductCard cardScript);
    }
}
