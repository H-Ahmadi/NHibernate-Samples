using System;
using Configuration;
using FizzWare.NBuilder;
using FluentAssertions;
using ValueObject.Model;
using Xunit;

namespace ValueObject
{
    public class ComponentMappingTests : PersistenceTest
    {
        [Fact]
        public void should_save_value_object()
        {
            var session = SessionFactory.OpenSession();

            var airport = Builder<Airport>.CreateNew().Build();
            airport.Coordinate = new Coordinate(){ Longitude = 100, Latitude = 200};

            session.BeginTransaction();
            session.Save(airport);
            session.Transaction.Commit();

            var loadedAirport = LoadAirport(airport.Id);

            loadedAirport.Should().BeEquivalentTo(airport);
        }

        private Airport LoadAirport(long airportId)
        {
            return SessionFactory.OpenSession().Get<Airport>(airportId);
        }
    }
}
