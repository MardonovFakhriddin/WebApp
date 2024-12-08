using Dapper;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Services;
using Infrastructure.Interfaces;

public class CompanyService : ICompany
{
    private readonly DapperContext context;

    public CompanyService()
    {
        context = new DapperContext();
    }

    public bool InsertCompany(Company company)
    {
        try
        {
            string cmd = """INSERT INTO Company (company_name, company_address, company_phone) VALUES (@company_name, @company_address, @company_phone)""";
            var inserted = context.Connection.Execute(cmd, company);
            return inserted > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool UpdateCompany(Company company)
    {
        try
        {
            string cmd = $"""UPDATE Company SET company_name=@company_name, company_address=@company_address, company_phone=@company_phone WHERE company_id=@company_id""";
            int updated = context.Connection.Execute(cmd, company);
            return updated > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool DeleteCompany(int id)
    {
        try
        {
            string cmd = "DELETE FROM Company WHERE company_id = @company_id";
            var deleted = context.Connection.Execute(cmd, new { company_id = id });
            return deleted > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public List<Company> GetCompanies()
    {
        try
        {
            string cmd = "SELECT * FROM Company";
            List<Company> companies = context.Connection.Query<Company>(cmd).ToList();
            return companies;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Company GetCompanyById(int id)
    {
        try
        {
            string cmd = "SELECT * FROM Company WHERE company_id = @company_id";
            Company company = context.Connection.QuerySingleOrDefault<Company>(cmd, new { company_id = id });
            return company;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}