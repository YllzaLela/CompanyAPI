using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CompanyAPI.Models
{
	public class Employee
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int EmployeeId { get; set; }

		[Required]
		[MaxLength(200)]
		public string FirstName { get; set; }

		[Required]
		[MaxLength(400)]
		public string LastName { get; set; }

		[Required]
		public DateTime DOB { get; set; }

		[Required]
		public DateTime SigningDate { get; set; }

		public double Salary { get; set; }

		[Required]
		[ForeignKey("Company")]
		public int CompanyId { get; set; }


	}
}
