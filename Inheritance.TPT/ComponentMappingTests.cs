using Configuration;
using FizzWare.NBuilder;
using FluentAssertions;
using Inheritance.TPT.Model;
using Xunit;

namespace Inheritance.TPT
{
    public class ComponentMappingTests : PersistenceTest
    {
        [Fact]
        public void should_save_legal_party()
        {
            var session = SessionFactory.OpenSession();

            var party = Builder<LegalParty>.CreateNew().Build();

            session.BeginTransaction();
            session.Save(party);
            session.Transaction.Commit();

            var loadedParty = LoadParty<LegalParty>(party.Id);

            loadedParty.Should().BeEquivalentTo(party);
        }

        private T LoadParty<T>(long partyId) where T : Party
        {
            return SessionFactory.OpenSession().Get<T>(partyId);
        }
    }
}
