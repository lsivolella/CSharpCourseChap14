namespace Exercise03.Services
{
    class PaypalService : IOnlinePaymentService
    {
        private const double monthlyInterest = 0.01;
        private const double feePercantage = 0.02;

        public double Interest(double amount, int quota)
        {
            double interest = amount * monthlyInterest * quota;

            return interest;
        }

        public double PaymentFee(double amount)
        {
            double paymentFee = amount * feePercantage;

            return paymentFee;
        }
    }
}
