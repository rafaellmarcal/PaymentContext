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

        public StudentTests()
        {
            _name = new Name("Rafael", "Marçal");
            _email = new Email("rafael.marcal@ms.senac.br");
            _document = new Document("02880158192", EDocumentType.CPF);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHasActiveSubscription()
        {
            var student = new Student(_name, _document, _email);



            Assert.Fail();
            // var name = new Name("Rafael", "Marçal");
            // foreach (var not in name.Notifications)
            // {
            //     Console.WriteLine(not.Message);
            // }
        }

        [TestMethod]
        public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
        {
            var student = new Student(_name, _document, _email);

    

            Assert.Fail();
            // var name = new Name("Rafael", "Marçal");
            // foreach (var not in name.Notifications)
            // {
            //     Console.WriteLine(not.Message);
            // }
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenHasNoActiveSubscription()
        {
            Assert.Fail();

            // var name = new Name("Rafael", "Marçal");
            // foreach (var not in name.Notifications)
            // {
            //     Console.WriteLine(not.Message);
            // }
        }
    }
}