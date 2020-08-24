using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentTests
    {
        private Name _name;
        private Email _email;
        private Document _document;
        private Subscription _subscription;
        private Payment _payment;
        private Address _address;

        public StudentTests()
        {
            _name = new Name("Rafael", "Marçal");
            _email = new Email("rafael.marcal@ms.senac.br");
            _document = new Document("02880158192", EDocumentType.CPF);
            _subscription = new Subscription(null);
            _address = new Address("Rua Cataguases", "302", "Novos Estados", "Campo Grande", "MS", "Brasil", "79034050");
            _payment = new PayPalPayment(_email, "ABCDEFG", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Rafael Marcal", _document, _address);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHasActiveSubscription()
        {
            var student = new Student(_name, _document, _email);

            _subscription.AddPayment(_payment);
            student.AddSubscription(_subscription);
            student.AddSubscription(_subscription);

            Assert.IsTrue(student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
        {
            var student = new Student(_name, _document, _email);

            student.AddSubscription(_subscription);

            Assert.IsTrue(student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenHasNoActiveSubscription()
        {
            var student = new Student(_name, _document, _email);

            _subscription.AddPayment(_payment);
            student.AddSubscription(_subscription);

            Assert.IsTrue(student.Valid);
        }
    }
}