using System;
using System.Collections.Generic;

namespace EntityFrameWorkCore_DBFirst_4DBCommunication.hotelmanagementModels;

public partial class BankAccount
{
    public int? Id { get; set; }

    public string? AccountName { get; set; }

    public string? Location { get; set; }
}
