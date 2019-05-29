using System;
using System.Globalization;
using Configuration;
using FizzWare.NBuilder;
using FluentAssertions;
using NHibernate;
using OptimisticConcurrency.Model;
using Xunit;

namespace OptimisticConcurrency
{
    public class OptimisticConcurrencyTests : PersistenceTest
    {
        [Fact]
        public void should_throw_concurrency_exception()
        {
            var session = SessionFactory.OpenSession();
            var person = Builder<Person>.CreateNew().Build();
            session.BeginTransaction();
            session.Save(person);
            session.Transaction.Commit();

            var fetchPerson = session.Get<Person>(1L);
            UpdatePersonFromAnotherTransaction();
            fetchPerson.Firstname = Faker.Name.First();
            session.BeginTransaction();
            session.Save(fetchPerson);
            Action commit =() => session.Transaction.Commit();

            commit.Should().Throw<StaleStateException>();
        }

        private void UpdatePersonFromAnotherTransaction()
        {
            var session = SessionFactory.OpenSession();
            var person = session.Get<Person>(1L);
            person.Firstname = Faker.Name.Last();
            session.BeginTransaction();
            session.Save(person);
            session.Transaction.Commit();
        }
    }
}
