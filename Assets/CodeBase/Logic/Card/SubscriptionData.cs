namespace CodeBase.Logic.Card
{
    [System.Serializable]
    public class SubscriptionData : Product
    {
        public int DurationMonths;
        public bool AutoRenew;


        public override void SetupCard(ProductCard cardScript)
        {
            cardScript.SetupSubscription(this);
        }
    }
}