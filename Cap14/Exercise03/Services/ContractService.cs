using Exercise03.Entities;
using System;

namespace Exercise03.Services
{
    class ContractService
    {
        private IOnlinePaymentService paymentService;

        public ContractService(IOnlinePaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        public void ProcessContract(Contract contract, int monthsDuration)
        {
            double basicQuota = contract.TotalValue / monthsDuration;

            for (int i = 1; i <= monthsDuration; i++)
            {
                DateTime date = contract.Date.AddMonths(i);
                double updatedQuota = basicQuota + paymentService.Interest(basicQuota, i);
                double fullQuota = updatedQuota + paymentService.PaymentFee(updatedQuota);
                contract.AddInstallment(new Installment(date, fullQuota));
            }
        }
    }
}
