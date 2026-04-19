using EntityFrameWorkCore_DBFirst_4DBCommunication.Dtos;
using EntityFrameWorkCore_DBFirst_4DBCommunication.hotelmanagementModels;
using EntityFrameWorkCore_DBFirst_4DBCommunication.Interfaces;

namespace EntityFrameWorkCore_DBFirst_4DBCommunication.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<int> AddEmployes(EmployeeDto empdetail)
        {
            Employee emp = new Employee();
            emp.Empid = empdetail.Empid;
            emp.Empsalary = empdetail.Empsalary;
            emp.Empname = empdetail.Empname;
            var res = await _employeeRepository.AddEmployes(emp);
            return res;
        }

        public async Task<bool> DeleteEmployesById(int empid)
        {
            await _employeeRepository.DeleteEmployesById(empid);
            return true;
        }

        public async Task<EmployeeDto> GetEmployeeById(int empid)
        {
            var res = await _employeeRepository.GetEmployeeById(empid);
            EmployeeDto empdto = new EmployeeDto();
            empdto.Empid = res.Empid;
            empdto.Empname = res.Empname;
            empdto.Empsalary = res.Empsalary;
            return empdto;
        }

        public async Task<List<EmployeeDto>> GetEmployees()
        {

            List<EmployeeDto> lstempdto = new List<EmployeeDto>();
            var res = await _employeeRepository.GetEmployees();
            foreach (Employee emp in res)
            {
                EmployeeDto empdto = new EmployeeDto();
                empdto.Empid = emp.Empid;
                empdto.Empsalary = emp.Empsalary;
                empdto.Empname = emp.Empname;
                lstempdto.Add(empdto);

            }
            return lstempdto;
        }

        public async Task<bool> UpdateEmploye(EmployeeDto empdetail)
        {
            Employee emp = new Employee();
            emp.Empid = empdetail.Empid;
            emp.Empsalary = empdetail.Empsalary;
            emp.Empname = empdetail.Empname;
            await _employeeRepository.UpdateEmploye(emp);
            return true;
        }
    }
}
