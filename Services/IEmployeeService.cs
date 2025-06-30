// Services/IEmployeeService.cs
using EmployeeManagementAPI.Models;
namespace EmployeeManagementAPI.Services;

public interface IEmployeeService
{
    Task<List<Employee>> GetAllAsync();
    Task<Employee?> GetByIdAsync(int id);
    Task<Employee> AddAsync(Employee employee);
    Task<Employee?> UpdateAsync(Employee employee);
    Task<bool> DeleteAsync(int id);
}
