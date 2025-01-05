namespace CodeBase.Logic.Card
{
    [System.Serializable]
    public class BoosterData : Product
    {
        public string BoosterType;

        public override void SetupCard(ProductCard cardScript)
        {
            cardScript.SetupBooster(this);
        }
    }
}