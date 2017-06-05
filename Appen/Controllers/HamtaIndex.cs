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
					.Query<Ort>()
					.ToList()
                    .Select(p => p.Ortnamn);

                return existing;
			}
		}

        public IEnumerable<string> HamtaPerson()
        {
			var store = DocumentStore.For(_ =>
			{
				_.Connection(connectionString);
				_.DatabaseSchemaName = "appen";
			});

			using (var session = store.OpenSession())
			{
                var dict = new Dictionary<Guid, Ort>();

                var existing = session
                    .Query<Person>()
                    .Include(x => x.OrtId, dict)
                    .ToList()
                    .Select(h => h.Namn + " " + dict.FirstOrDefault(p => p.Value.Id == h.OrtId).Value.Ortnamn);
                
				return existing;
			}
		}
    }
}
