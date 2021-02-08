namespace Exercise03.Services
{
    interface IOnlinePaymentService
    {
        double Interest(double amount, int quota);
        double PaymentFee(double amount);
    }
}
