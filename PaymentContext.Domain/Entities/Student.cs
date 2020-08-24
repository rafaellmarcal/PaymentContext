using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }

        private IList<Subscription> _subscriptions;
        public IReadOnlyCollection<Subscription> Subscriptions
        {
            get
            {
                return _subscriptions.ToArray();
            }
        }

        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();

            AddNotifications(Name, Document, Email);
        }

        public void AddSubscription(Subscription subscription)
        {
            var hasSubscriptionActive = false;

            foreach (var sub in _subscriptions)
                if (sub.Active)
                    hasSubscriptionActive = true;

            if (!hasSubscriptionActive)
                _subscriptions.Add(subscription);

            AddNotifications(new Contract()
                .Requires()
                .AreEquals(true, hasSubscriptionActive, "Student.Subscriptions", "Você já tem uma assinatura ativa!")
                .IsLowerOrEqualsThan(0, subscription.Payments.Count, "Student.Subscription.Payments", "Essa assinatura não possui pagamento!")
            );
        }
    }
}