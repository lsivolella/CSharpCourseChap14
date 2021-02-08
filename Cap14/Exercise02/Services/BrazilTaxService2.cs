namespace Exercise02.Services
{
    class BrazilTaxService2 : ITaxService
    {
        public double Tax(double amount)
        {
            double taxes = 0;

            if (amount <= 100.00)
                taxes = amount * 0.20;
            else
                taxes = amount * 0.15;

            return taxes;
        }
    }
}
