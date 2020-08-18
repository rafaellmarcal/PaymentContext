using PaymentContext.Domain.Enums;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public string Number { get; private set; }
        public EDocumentType Type { get; private set; }

        public Document(string number, EDocumentType type)
        {
            Number = number;
            Type = type;
        }
    }
}