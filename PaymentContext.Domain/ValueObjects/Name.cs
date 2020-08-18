using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            if (string.IsNullOrWhiteSpace(FirstName))
                AddNotification("Name.FirstName", "Nome inválido");
        }
    }
}