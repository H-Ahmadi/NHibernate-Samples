using CompositeId.Model;
using Configuration;
using FizzWare.NBuilder;
using FluentAssertions;
using Xunit;

namespace CompositeId
{
    public class CompositeIdTests : PersistenceTest
    {
        [Fact]
        public void should_save_object_with_two_ids()
        {
            var session = SessionFactory.OpenSession();
            var transaction = Builder<InventoryTransaction>.CreateNew()
                .With(a=>a.Id = Builder<InventoryTransactionId>.CreateNew().Build())
                .Build();

            session.BeginTransaction();
            session.Save(transaction);
            session.Transaction.Commit();

            var loadedTransaction = LoadTransaction(transaction.Id);

            loadedTransaction.Should().BeEquivalentTo(transaction);
        }

        [Fact]
        public void should_save_object_with_single_id()
        {
            var session = SessionFactory.OpenSession();
            var realEstate = Builder<RealEstate>.CreateNew()
                .With(a => a.Id = Builder<RealEstateId>.CreateNew().Build())
                .Build();

            session.BeginTransaction();
            session.Save(realEstate);
            session.Transaction.Commit();

            var loadedRealEstate = LoadRealEstate(realEstate.Id);

            loadedRealEstate.Should().BeEquivalentTo(realEstate);
        }

        private RealEstate LoadRealEstate(RealEstateId id)
        {
            return SessionFactory.OpenSession().Get<RealEstate>(id);
        }

        private InventoryTransaction LoadTransaction(InventoryTransactionId id)
        {
            return SessionFactory.OpenSession().Get<InventoryTransaction>(id);
        }
    }
}
