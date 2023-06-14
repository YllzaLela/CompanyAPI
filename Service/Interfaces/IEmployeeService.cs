using CompanyAPI.WebAPI.Models.DTO;

namespace CompanyAPI.Service.Interfaces
{
    public interface IEmployeeService
	{
		IEnumerable<EmployeeDTO> GetEmployees();
		EmployeeDTO GetEmployee(int id);
		void AddEmployee(EmployeeDTO employee);
		void UpdateEmployee(EmployeeDTO employee);
		void DeleteEmployeeById(int id);
	}
}
