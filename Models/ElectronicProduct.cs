using System.ComponentModel.DataAnnotations;

namespace Models
{
	public class ElectronicProduct
	{
		[Display]
		public int Id { get; set; }

		public string? Name { get; set; }

		public string? Description { get; set; }

	}
}