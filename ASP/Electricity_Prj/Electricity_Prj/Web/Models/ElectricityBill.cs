using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Electricity_Prj.Web.Models
{
    public class ElectricityBill
    {
        private string consumerNumber;
        private string consumerName;
        private int unitsConsumed;
        private double billAmount;
        public string ConsumerNumber
        {
            get => consumerNumber;
            set
            {
                // Validation: EB + 5 digits
                if (string.IsNullOrWhiteSpace(value) ||
                    !System.Text.RegularExpressions.Regex.IsMatch(value, @"^EB\d{5}$"))
                    throw new FormatException("Invalid Consumer Number");
                consumerNumber = value;
            }
        }

        public string ConsumerName
        {
            get => consumerName;
            set => consumerName = value ?? string.Empty;
        }

        public int UnitsConsumed
        {
            get => unitsConsumed;
            set => unitsConsumed = value;
        }

        public double BillAmount
        {
            get => billAmount;
            set => billAmount = value;
        }
    }
}