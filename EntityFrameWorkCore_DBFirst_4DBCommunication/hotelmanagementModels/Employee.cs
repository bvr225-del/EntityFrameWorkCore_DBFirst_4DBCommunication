using System;
using System.Collections.Generic;

namespace EntityFrameWorkCore_DBFirst_4DBCommunication.hotelmanagementModels;

public partial class Employee
{
    public int Empid { get; set; }

    public string? Empname { get; set; }

    public decimal? Empsalary { get; set; }
}
