using System;
using Marten;
using System.Linq;
using Appen.Gemensam;
using System.Collections.Generic;

namespace Appen.Controllers
{
    public class HamtaIndex : IHamtaIndex
    {
		private string connectionString = "host=localhost;database=postgres;username=postgres";

		public IEnumerable<string> Hamta()
        {
			var store = DocumentStore.For(_ =>
			{
				_.Connection(connectionString);
				_.DatabaseSchemaName = "appen";
			});

			using (var session = store.OpenSession())
			{
				var existing = session
					.Query<Person>()
					.ToList()
                    .Select(p => p.Namn);

                return existing;
			}
		}

        public IEnumerable<string> HamtaHusdjur()
        {
			var store = DocumentStore.For(_ =>
			{
				_.Connection(connectionString);
				_.DatabaseSchemaName = "appen";
			});

			using (var session = store.OpenSession())
			{
				Person included = null;
				var existing = session
                    .Query<Husdjur>()
				    .Include<Person>(x => x.AgarId, x => included = x)
					.ToList()
                    .Select(h => h.Djurnamn + " " + included.Namn);
                
				return existing;
			}
		}
    }
}
