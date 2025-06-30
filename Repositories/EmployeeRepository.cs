// Repositories/EmployeeRepository.cs
using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Data;
using Microsoft.EntityFrameworkCore;
namespace EmployeeManagementAPI.Repositories;
public class EmployeeRepository : IEmployeeRepository
{
    private readonly AppDbContext _context;

    public EmployeeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Employee>> GetAllAsync() =>
        await _context.Employees.ToListAsync();

    public async Task<Employee?> GetByIdAsync(int id) =>
        await _context.Employees.FindAsync(id);

    public async Task<Employee> AddAsync(Employee employee)
    {
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task<Employee?> UpdateAsync(Employee employee)
    {
        var existing = await _context.Employees.FindAsync(employee.Id);
        if (existing == null) return null;

        existing.Name = employee.Name;
        existing.Email = employee.Email;
        existing.Department = employee.Department;
        existing.Salary = employee.Salary;

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee == null) return false;

        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
        return true;
    }
}
