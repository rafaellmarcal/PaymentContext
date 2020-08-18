using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class PayPalPayment : Payment
    {
        public Email Email { get; private set; }
        public string TransactionCode { get; private set; }

        public PayPalPayment(
            Email email, string transactionCode, DateTime paidDate,
            DateTime expireDate, decimal total, decimal totalPaid,
            string owner, Document document, Address address)
        : base(paidDate, expireDate, total, totalPaid, owner, document, address)
        {
            Email = email;
            TransactionCode = transactionCode;
        }
    }
}