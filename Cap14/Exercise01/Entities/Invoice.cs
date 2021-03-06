﻿using System.Globalization;
using System.Text;

namespace Exercise01.Entities
{
    class Invoice
    {
        public double BasicPayment { get; set; }
        public double Tax { get; set; }

        public Invoice(double basicPayment, double tax)
        {
            BasicPayment = basicPayment;
            Tax = tax;
        }

        // Calculated Propertie
        public double TotalPayment { get { return BasicPayment + Tax;  }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("Basic Payment: ");
            stringBuilder.AppendLine(BasicPayment.ToString("f2", CultureInfo.InvariantCulture));
            stringBuilder.Append("Taxes: ");
            stringBuilder.AppendLine(Tax.ToString("f2", CultureInfo.InvariantCulture));
            stringBuilder.Append("Total Payment: ");
            stringBuilder.AppendLine(TotalPayment.ToString("f2", CultureInfo.InvariantCulture));


            return stringBuilder.ToString();
        }
    }
}
