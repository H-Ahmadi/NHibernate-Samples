using System;
using Configuration;
using FluentAssertions;
using StatePattern.Model;
using Xunit;

namespace StatePattern
{
    public class StatePatternTests : PersistenceTest
    {
        [Fact]
        public void should_save_order_with_state()
        {
            var order = new Order(200);
            order.Confirm();
            SaveOrder(order);

            var loadedOrder = LoadOrder(order.Code);

            loadedOrder.Should().BeEquivalentTo(order);
        }

        private Order LoadOrder(long orderCode)
        {
            return SessionFactory.OpenSession().Load<Order>(orderCode);
        }

        private void SaveOrder(Order order)
        {
            var session = SessionFactory.OpenSession();
            session.BeginTransaction();
            session.Save(order);
            session.Transaction.Commit();
        }
    }
}