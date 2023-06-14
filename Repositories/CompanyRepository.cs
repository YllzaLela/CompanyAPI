using CompanyAPI.Data;
using CompanyAPI.Repositories.Interfaces;
using CompanyAPI.WebAPI.Models;

namespace CompanyAPI.Repositories
{
    public class CompanyRepository : ICompanyRepository
	{
		private readonly CompanyAPIContext _context;

		public CompanyRepository(CompanyAPIContext context)
		{
			_context = context; //Injecting the context
		}

		public IEnumerable<Company> GetCompanies()
		{
			return _context.Company.ToList();
		}

		public Company GetCompany(int id)
		{
			return _context.Company.FirstOrDefault(c => c.CompanyId == id);
		}

		public void AddCompany(Company company)
		{
			_context.Company.Add(company);
			_context.SaveChanges();
		}

		public void UpdateCompany(Company company)
		{
			var companyToUpdate = GetCompany(company.CompanyId);
			if (companyToUpdate != null)
			{
				companyToUpdate.Name = company.Name;
				companyToUpdate.Owner = company.Owner;
				companyToUpdate.City = company.City;
				companyToUpdate.Country = company.Country;
				_context.SaveChanges();
			}
		}

		public void DeleteCompanyById(int id)
		{
			var company = GetCompany(id);
			if (company != null)
			{
				_context.Company.Remove(company);
				_context.SaveChanges();
			}


		}
	}
}
