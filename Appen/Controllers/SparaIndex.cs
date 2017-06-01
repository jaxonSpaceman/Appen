using Appen.Gemensam;
using Marten;
using System.Linq;

namespace Appen.Controllers
{
    public class SparaIndex : ISparaIndex
    {
        private string connectionString = "host=localhost;database=postgres;username=postgres";

        public void Spara(string namn, string djurnamn)
        {
            var store = DocumentStore.For(_ =>
            {
                _.Connection(connectionString);
                _.DatabaseSchemaName = "appen";
            });

			using (var session = store.LightweightSession())
			{
                var person = new Person { Namn = namn };
                var husdjur = new Husdjur { Djurnamn = djurnamn, AgarId = person.Id };

                session.Store<object>(person, husdjur);
				session.SaveChanges();
			}
		}
	}
}