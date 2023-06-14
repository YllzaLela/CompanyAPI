using CompanyAPI.Repositories.Interfaces;
using CompanyAPI.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using CompanyAPI.WebAPI.Models;

namespace CompanyAPI.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
	{
		private readonly CompanyAPIContext _context;
		public EmployeeRepository(CompanyAPIContext context)
		{
			_context = context;
		}
		public IEnumerable<Employee> GetEmployees()
		{
			return _context.Employee.ToList();
		}
		public Employee GetEmployee(int id)
		{
			var employee = _context.Employee.FirstOrDefault(e => e.EmployeeId == id);
			if (employee == null)
			{
				throw new Exception("Employee not found");
			}
			return employee;
		}
		public void AddEmployee(Employee employee)
		{
			_context.Employee.Add(employee);
			_context.SaveChanges();
		}
		public void UpdateEmployee(Employee employee)
		{
			var employeeToUpdate = GetEmployee(employee.EmployeeId);
			if (employeeToUpdate != null)
			{
				employeeToUpdate.FirstName = employee.FirstName;
				employeeToUpdate.LastName = employee.LastName;
				employeeToUpdate.DOB = employee.DOB;
				employeeToUpdate.SigningDate = employee.SigningDate;
				employeeToUpdate.Salary = employee.Salary;
				employeeToUpdate.CompanyId = employee.CompanyId;
				_context.SaveChanges();
			}
		}

		public void DeleteEmployeeById(int id)
		{
			var employee = GetEmployee(id);
			if (employee != null)
			{
				_context.Employee.Remove(employee);
				_context.SaveChanges();
			}
		}

	}
}
