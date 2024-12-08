namespace Infrastructure.Interfaces;
using Domain.Models;

public interface IDepartment
{
    bool InsertDepartment (Department department);
    bool UpdateDepartment(Department department);
    bool deleteDepartment (int id);
    List<Department> GetDepartments();
    Department GetDepartmentById(int id);
}