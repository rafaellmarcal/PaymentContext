using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class BoletoPayment : Payment
    {
        public string BarCode { get; private set; }
        public Email Email { get; private set; }
        public string BoletoNumber { get; private set; }

        public BoletoPayment(string barCode, Email email, string boletoNumber,
            DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid,
            string owner, Document document, Address address)
        : base(paidDate, expireDate, total, totalPaid, owner, document, address)
        {
            BarCode = barCode;
            Email = email;
            BoletoNumber = boletoNumber;
        }
    }
}