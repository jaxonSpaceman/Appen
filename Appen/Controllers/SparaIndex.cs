using Appen.Gemensam;
using Marten;
using System.Linq;

namespace Appen.Controllers
{
    public class SparaIndex : ISparaIndex
    {
        private string connectionString = "host=localhost;database=postgres;username=postgres";

        public void Spara(string namn, string ortnamn)
        {
            var store = DocumentStore.For(_ =>
            {
                _.Connection(connectionString);
                _.DatabaseSchemaName = "appen";
            });

			using (var session = store.LightweightSession())
			{
                var ort = new Ort { Ortnamn = ortnamn };
                var person = new Person { Namn = namn, OrtId = ort.Id };

                session.Store<object>(ort, person);
				session.SaveChanges();
			}
		}
	}
}