using EntityFrameWorkCore_DBFirst_4DBCommunication.Dtos;
using EntityFrameWorkCore_DBFirst_4DBCommunication.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameWorkCore_DBFirst_4DBCommunication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _deptservice;
        //DepartmentService obj = new DepartmentService();tightlycouplyed

        public DepartmentController(IDepartmentService deptservice)//Constructor injection
        {
            _deptservice = deptservice;
        }
        [HttpPost]
        [Route("AddDepartment")]
        public async Task<IActionResult> Post([FromBody] DepartmentDto deptdto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var empdata = await _deptservice.AddDepartments(deptdto);
                    return StatusCode(StatusCodes.Status201Created, empdata);
                }
            }
            catch (Exception ex)
            {//if you got any error we are using this statuscode:Status500InternalServerError
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
        [HttpDelete]
        [Route("DeleteDepartmentByEmpid/{deptid}")]
        public async Task<IActionResult> delete([FromRoute] int deptid)
        {
            if (deptid < 0)
            {//If input parameters are wrongly sent or empty, we will get 400 badrequest statuscode:Status400BadRequest
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var deptdata = await _deptservice.DeleteDepartmentById(deptid);
                if (deptdata == null)
                {//in db if you get empty data we need to retrun this statuscode:Status404NotFound
                    return StatusCode(StatusCodes.Status404NotFound, "deptdata not  found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, "deleted successfully");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
        [HttpGet]
        [Route("GetDepartment")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var deptdata = await _deptservice.GetDepartments();
                if (deptdata == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "deptdata not  found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, deptdata);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }

        }
        [HttpGet]
        [Route("GetDepartmentByDeptid/{deptid}")]
        public async Task<IActionResult> Get(int deptid)
        {
            if (deptid < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var deptdata = await _deptservice.GetDepartmentById(deptid);
                return StatusCode(StatusCodes.Status200OK, deptdata);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server eror");
            }
        }
        [HttpPut]
        [Route("UpdateDepartment")]
        public async Task<IActionResult> put([FromBody] DepartmentDto deptdto)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var empdata = await _deptservice.UpdateDepartment(deptdto);
                    return StatusCode(StatusCodes.Status200OK, empdata);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }

    }
}
/* DbFirstApproach Scaffold-Statement:
 * ===================================

PM> Scaffold-DbContext "Server=DESKTOP-13B42NJ;Database=Northwind_DB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir NorthWind_DbModels
Build started...
Build succeeded.
To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
PM> 


To fix that primary key issue we  need to add the primary key to that table
=====================================================
creating the primary key after creating the table.(add below command in NorthWin_db database)
====================================

ALTER TABLE Department ADD CONSTRAINT PK_Department PRIMARY KEY (deptid);
 
 ==========
ONCE YOU ADD PRIMARY KEY,APPLY BELOW COMMAND.
===================
🔹 Command to update models

Run the same command again with -Force:(USE   -fORCE AT ENDING OF STATEMENT)IF ANY DB MODIFICATIONS PERFOMED AND TO EFFECT THOSE CHANGES TO OUR ENTITY CLASSES.
==========================================
PM>Scaffold-DbContext "Server=DESKTOP-13B42NJ;Database=Northwind_DB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir NorthWind_DbModels -Force
=============================

👉 -Force = overwrite existing models & DbContext
 
*/