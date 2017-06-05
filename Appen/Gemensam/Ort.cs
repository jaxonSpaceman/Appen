using System;
using Marten.Schema;

namespace Appen.Gemensam
{
	public class Ort
	{
        public Ort()
        {
            Id = Guid.NewGuid();
        }

		public Guid Id { get; set; }

		[DuplicateField(PgType = "varchar(50)")]
		public string Ortnamn { get; set; }
	}
}
