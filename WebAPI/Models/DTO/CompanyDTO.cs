using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CompanyAPI.Models.DTO
{
	public class CompanyDTO
	{
		public int CompanyId { get; set; }
		public string Name { get; set; }
		public string Owner { get; set; }
		public string City { get; set; }
		public string Country { get; set; }
	}
}
