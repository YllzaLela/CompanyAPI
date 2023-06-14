using CompanyAPI.WebAPI.Models;

namespace CompanyAPI.Repositories.Interfaces
{
    public interface IEmployeeRepository
	{
		IEnumerable<Employee> GetEmployees();
		Employee GetEmployee(int id);
		void AddEmployee(Employee employee);
		void UpdateEmployee(Employee employee);
		void DeleteEmployeeById(int id);
	}
}
