using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CompanyAPI.Models.DTO
{
	public class EmployeeDTO
	{
		public int EmployeeId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DOB { get; set; }
		public DateTime SigningDate { get; set; }
		public double Salary { get; set; }
		public int CompanyId { get; set; }
	}
}
