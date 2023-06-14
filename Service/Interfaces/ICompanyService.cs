using CompanyAPI.WebAPI.Models.DTO;

namespace CompanyAPI.Service.Interfaces
{
    public interface ICompanyService
	{
		IEnumerable<CompanyDTO> GetCompanies();
		CompanyDTO GetCompany(int id);
		void AddCompany(CompanyDTO company);
		void UpdateCompany(CompanyDTO company);
		void DeleteCompanyById(int id);
	}
}
