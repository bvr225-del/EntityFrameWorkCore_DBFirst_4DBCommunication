using EntityFrameWorkCore_DBFirst_4DBCommunication.Dtos;

namespace EntityFrameWorkCore_DBFirst_4DBCommunication.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<DepartmentDto>> GetDepartments();
        Task<DepartmentDto> GetDepartmentById(int deptid);
        Task<int> AddDepartments(DepartmentDto deptdetail);
        Task<bool> DeleteDepartmentById(int deptid);
        Task<bool> UpdateDepartment(DepartmentDto deptdetail);

    }
}
