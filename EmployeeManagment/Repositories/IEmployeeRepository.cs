﻿using EmployeeManagment.Models;
namespace EmployeeManagment.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(int id);
        Task AddEmployeeAsync(Employee employee);   
        Task DeleteEmployeeAsync(int id);
        Task UpdateEmployeeAsync(Employee employee);


    }
}
