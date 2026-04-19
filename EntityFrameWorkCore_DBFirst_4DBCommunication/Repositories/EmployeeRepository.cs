using EntityFrameWorkCore_DBFirst_4DBCommunication.hotelmanagementModels;
using EntityFrameWorkCore_DBFirst_4DBCommunication.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWorkCore_DBFirst_4DBCommunication.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HotelmanagementContext _hotelManagementContext;

        public EmployeeRepository(HotelmanagementContext hotelManagementContext)
        {
            _hotelManagementContext = hotelManagementContext;
        }
        public async Task<int> AddEmployes(Employee empdetail)
        {
            await _hotelManagementContext.Employees.AddAsync(empdetail);
            _hotelManagementContext.SaveChanges();
            return 1;
        }

        public async Task<bool> DeleteEmployesById(int empid)
        {
            var result = await _hotelManagementContext.Employees.Where(a => a.Empid == empid).FirstOrDefaultAsync();
            if (result != null)
            {
                _hotelManagementContext.Employees.Remove(result);
                _hotelManagementContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Employee> GetEmployeeById(int empid)
        {
            //To get the one record use below linq query
            var result = await _hotelManagementContext.Employees.Where(b => b.Empid == empid).FirstOrDefaultAsync();
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Employee>> GetEmployees()
        {
            var result = await _hotelManagementContext.Employees.ToListAsync();
            if (result.Count == 0)
            {
                return null;
            }
            else
            {
                return result;
            }
        }

        public async Task<bool> UpdateEmploye(Employee empdetail)
        {

            //this is one way of update the data
            //  _hotelManagementContext.Employees.Update(empdetail);

            //second way of update the data(Realtime use this way)
            var employeeResult = await _hotelManagementContext.Employees.Where(b => b.Empid == empdetail.Empid).FirstOrDefaultAsync();
            employeeResult.Empid = empdetail.Empid;
            employeeResult.Empname = empdetail.Empname;
            employeeResult.Empsalary = empdetail.Empsalary;
            _hotelManagementContext.Employees.Update(employeeResult);
            await _hotelManagementContext.SaveChangesAsync();
            return true;
        }
    }
}
