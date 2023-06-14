using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CompanyAPI.Models
{
	public class Company
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CompanyId { get; set; }

		[Required]
		[MaxLength(200)]
		public string Name { get; set; }

		[Required]
		[MaxLength(200)]
		public string Owner { get; set; }

		[Required]
		[MaxLength(200)]
		public string City { get; set; }

		[Required]
		[MaxLength(200)]
		public string Country { get; set; }

		//List of employees
		//public List<Employee> Employees { get; set; }
	}
}
