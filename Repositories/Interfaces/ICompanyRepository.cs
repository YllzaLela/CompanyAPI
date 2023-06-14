using CompanyAPI.WebAPI.Models;

namespace CompanyAPI.Repositories.Interfaces
{
    public interface ICompanyRepository
	{
		IEnumerable<Company> GetCompanies();
		Company GetCompany(int id);
		void AddCompany(Company company);
		void UpdateCompany(Company company);
		void DeleteCompanyById(int id);

	}
}
