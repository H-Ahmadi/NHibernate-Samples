using System.Linq;
using CollectionOfValueObjects.Model;
using Configuration;
using FizzWare.NBuilder;
using FluentAssertions;
using Xunit;

namespace CollectionOfValueObjects
{
    public class ValueObjectMappingTests : PersistenceTest
    {
        [Fact]
        public void should_save_list_of_value_objects()
        {
            var session = SessionFactory.OpenSession();

            var order = Builder<Order>.CreateNew().Build();
            var items = Builder<OrderItem>.CreateListOfSize(2).Build().ToList();
            order.AssignItems(items);


            session.BeginTransaction();
            session.Save(order);
            session.Transaction.Commit();

            var loadedOrder = LoadOrder(order.Id);

            loadedOrder.Should().BeEquivalentTo(order);
        }

        private Order LoadOrder( long orderId)
        {
            return SessionFactory.OpenSession().Get<Order>(orderId);
        }
    }
}
