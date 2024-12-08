using Dapper;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Domain.Models;

namespace Infrastructure.Services;

public class DepartmentService : IDepartment
{
    private readonly DapperContext context;
    
    public DepartmentService()
    {
        context = new DapperContext();
    }
    
    public bool InsertDepartment(Department department)
    {
        try
        {
            string cmd = "INSERT INTO Department (department_name, company_id) VALUES (@department_name, @company_id)";
            var inserted = context.Connection.Execute(cmd, department);
            return inserted > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool UpdateDepartment(Department department)
    {
        try
        {
            string cmd = "UPDATE Department SET department_name=@department_name, company_id=@company_id WHERE department_id=@department_id";
            var updated = context.Connection.Execute(cmd, department);
            return updated > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool deleteDepartment(int id)
    {
        try
        {
            string cmd = "DELETE FROM Department WHERE department_id = @department_id";
            var deleted = context.Connection.Execute(cmd, new { department_id = id });
            return deleted > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public List<Department> GetDepartments()
    {
        try
        {
            string cmd = "SELECT * FROM Department";
            List<Department> departments = context.Connection.Query<Department>(cmd).ToList();
            return departments;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Department GetDepartmentById(int id)
    {
        try
        {
            string cmd = "SELECT * FROM Department WHERE department_id = @department_id";
            Department department = context.Connection.QuerySingleOrDefault<Department>(cmd, new { department_id = id });
            return department;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}