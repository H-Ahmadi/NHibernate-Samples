using Configuration;
using FizzWare.NBuilder;
using FluentAssertions;
using Inheritance.TPH.Model;
using Xunit;

namespace Inheritance.TPH
{
    public class TphInheritanceTests : PersistenceTest
    {
        [Fact]
        public void should_save_debit()
        {
            var session = SessionFactory.OpenSession();

            var debit = Builder<Debit>.CreateNew().Build();

            session.BeginTransaction();
            session.Save(debit);
            session.Transaction.Commit();

            var loadedDebit = LoadDebit(debit.Id);

            loadedDebit.Should().BeEquivalentTo(debit);
        }

        private Debit LoadDebit(long transactionId)
        {
            return SessionFactory.OpenSession().Get<Debit>(transactionId);
        }
    }
}
