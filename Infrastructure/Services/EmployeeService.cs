using Dapper;
using Infrastructure.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Services;

public class EmployeeService : IEmployee
{
    private readonly DapperContext context;

    public EmployeeService()
    {
        context = new DapperContext();
    }

    public bool InsertEmploy(Employee employee)
    {
        try
        {
            string cmd = "INSERT INTO Employee (full_name, email, phone_number, department_id, branch_id) VALUES (@full_name, @email, @phone_number, @department_id, @branch_id)";
            var inserted = context.Connection.Execute(cmd, employee);
            return inserted > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool UpdateEmploy(Employee employee)
    {
        try
        {
            string cmd = "UPDATE Employee SET full_name=@full_name, email=@email, phone_number=@phone_number, department_id=@department_id, branch_id=@branch_id WHERE employee_id=@employee_id";
            int updated = context.Connection.Execute(cmd, employee);
            return updated > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool DeleteEmploy(int id)
    {
        try
        {
            string cmd = "DELETE FROM Employee WHERE employee_id = @employee_id";
            var deleted = context.Connection.Execute(cmd, new { employee_id = id });
            return deleted > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public List<Employee> GetEmployees()
    {
        try
        {
            string cmd = "SELECT * FROM Employee";
            List<Employee> employees = context.Connection.Query<Employee>(cmd).ToList();
            return employees;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Employee GetEmployeeById(int id)
    {
        try
        {
            string cmd = "SELECT * FROM Emloyee WHERE Emlpoyee_id = @employee_id";
            Employee employee = context.Connection.QuerySingleOrDefault<Employee>(cmd, new { employee_id = id });
            return employee;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}