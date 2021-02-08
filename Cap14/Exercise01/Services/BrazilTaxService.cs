namespace Exercise01.Services
{
    class BrazilTaxService
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
