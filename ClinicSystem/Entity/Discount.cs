namespace ClinicSystem.UserLoginForm
{
    public class Discount
    {

        private string discounttype;
        private string discountdiscription;
        private double discountRate;

        public Discount(string discounttype, string discountdiscription,double discountRate)
        {
            this.discounttype = discounttype;
            this.discountdiscription = discountdiscription;
            this.discountRate = discountRate;
        }

        public double DiscountRate { get => discountRate; }
        public string Discounttype { get => discounttype; }
        public string Discountdiscription { get => discountdiscription;  }
    }
}