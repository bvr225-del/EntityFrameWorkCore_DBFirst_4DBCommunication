using EntityFrameWorkCore_DBFirst_4DBCommunication.Interfaces;
using EntityFrameWorkCore_DBFirst_4DBCommunication.NorthWind_DbModels;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWorkCore_DBFirst_4DBCommunication.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly NorthwindDbContext _northWindDbContext;
        public DepartmentRepository(NorthwindDbContext northwindDbContext)
        {
            _northWindDbContext = northwindDbContext;
        }
        public async Task<int> AddDepartments(Department deptdetail)
        {
            //throw new NotImplementedException();//It will throw the error,
            await _northWindDbContext.Departments.AddAsync(deptdetail);//add the record by using addasync
            _northWindDbContext.SaveChanges();//it will commit/save the data perminently in table
            return 1;

        }

        public async Task<bool> DeleteDepartmentById(int deptid)
        {
            var result = await _northWindDbContext.Departments.Where(a => a.Deptid == deptid).FirstOrDefaultAsync();
            if (result != null)
            {
                _northWindDbContext.Departments.Remove(result);
                _northWindDbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Department> GetDepartmentById(int deptid)
        {
            //To get the one record use below linq query
            var result = await _northWindDbContext.Departments.Where(b => b.Deptid == deptid).FirstOrDefaultAsync();
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Department>> GetDepartments()
        {
            var result = await _northWindDbContext.Departments.ToListAsync();
            if (result.Count == 0)
            {
                return null;
            }
            else
            {
                return result;
            }
        }

        public async Task<bool> UpdateDepartment(Department deptdetail)
        {
            //this is one way of update the data
            //  _northWindDbContext.Departments.Update(deptdetail);

            //second way of update the data(Realtime use this way)
            var departmentResult = await _northWindDbContext.Departments.Where(b => b.Deptid == deptdetail.Deptid).FirstOrDefaultAsync();
            departmentResult.Deptid = deptdetail.Deptid;
            departmentResult.Deptname = deptdetail.Deptname;//map the properties clearly
            departmentResult.Deptlocation = deptdetail.Deptlocation;
            _northWindDbContext.Departments.Update(departmentResult);
            await _northWindDbContext.SaveChangesAsync();
            return true;

        }
    }
}
