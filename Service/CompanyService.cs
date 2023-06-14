using AutoMapper;
using CompanyAPI.Repositories.Interfaces;
using CompanyAPI.Service.Interfaces;
using CompanyAPI.WebAPI.Models;
using CompanyAPI.WebAPI.Models.DTO;

namespace CompanyAPI.Service
{
    public class CompanyService : ICompanyService
	{
		private readonly ICompanyRepository _companyRepository;
		private readonly IMapper _mapper;
		public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
		{
			_companyRepository = companyRepository;
			_mapper = mapper;
		}

		public IEnumerable<CompanyDTO> GetCompanies()
		{
			IEnumerable<Company> companies = _companyRepository.GetCompanies();
			IEnumerable<CompanyDTO> companiesDTO = _mapper.Map<IEnumerable<CompanyDTO>>(companies);
			return companiesDTO;
		}

		public CompanyDTO GetCompany(int id)
		{
			Company company= _companyRepository.GetCompany(id);
			CompanyDTO companyDTO = _mapper.Map<CompanyDTO>(company);
			return companyDTO;
		}

		public void AddCompany(CompanyDTO companyDTO)
		{
			Company company = _mapper.Map<Company>(companyDTO);
			_companyRepository.AddCompany(company);
		}


		public void UpdateCompany(CompanyDTO companyDTO)
		{
			Company company = _mapper.Map<Company>(companyDTO);
			_companyRepository.UpdateCompany(company);
		}

		public void DeleteCompanyById(int id)
		{
			_companyRepository.DeleteCompanyById(id);
		}
	}
}
