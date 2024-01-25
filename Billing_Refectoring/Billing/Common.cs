namespace Billing
{
    public class Common
    {
        #region Constants
        public const int MaxBooks = 5;
        public const decimal BookPrice = 8m;
        #endregion

        #region Methods
        public static decimal GetDiscount(int n)
        {
            decimal discount;
            switch (n)
            {
                case 2:
                    discount = 0.05m;
                    break;
                case 3:
                    discount = 0.10m;
                    break;
                case 4:
                    discount = 0.20m;
                    break;
                case 5:
                    discount = 0.25m;
                    break;
                default:
                    discount = 0;
                    break;
            }
            return discount;
        }
        #endregion
    }
}
