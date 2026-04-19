using EntityFrameWorkCore_DBFirst_4DBCommunication.hotelmanagementModels;

namespace EntityFrameWorkCore_DBFirst_4DBCommunication.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployeeById(int empid);
        Task<int> AddEmployes(Employee empdetail);
        Task<bool> DeleteEmployesById(int empid);
        Task<bool> UpdateEmploye(Employee empdetail);

    }
}
