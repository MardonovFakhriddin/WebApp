namespace Infrastructure.Interfaces;
using Domain.Models;

public interface IEmployee
{
    bool InsertEmploy(Employee employee);
    bool UpdateEmploy(Employee employee);
    bool DeleteEmploy(int id);
    List<Employee> GetEmployees();
    Employee GetEmployeeById(int id);
}