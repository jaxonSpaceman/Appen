using System;
using Marten.Schema;

namespace Appen.Gemensam
{
	public class Person
	{
        public Person()
        {
            Id = Guid.NewGuid();
        }

		public Guid Id { get; set; }

		[DuplicateField(PgType = "varchar(50)")]
		public string Namn { get; set; }
	}
}
