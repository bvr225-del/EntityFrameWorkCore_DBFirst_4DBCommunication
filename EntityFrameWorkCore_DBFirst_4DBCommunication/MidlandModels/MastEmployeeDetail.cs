using System;
using System.Collections.Generic;

namespace EntityFrameWorkCore_DBFirst_4DBCommunication.MidlandModels;

public partial class MastEmployeeDetail
{
    public int EmpId { get; set; }

    public string? EmpName { get; set; }

    public decimal? EmpSalary { get; set; }

    public string? EmpStatus { get; set; }

    public string? EmpDesignation { get; set; }
}
