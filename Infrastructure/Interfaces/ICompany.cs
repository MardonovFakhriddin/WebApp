namespace Infrastructure.Interfaces;
using Domain.Models;

public interface ICompany
{
    bool InsertCompany(Company company);
    bool UpdateCompany(Company company);
    bool DeleteCompany(int id);
    List<Company> GetCompanies();
    Company GetCompanyById(int id);
}