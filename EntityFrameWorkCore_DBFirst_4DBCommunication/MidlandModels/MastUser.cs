using System;
using System.Collections.Generic;

namespace EntityFrameWorkCore_DBFirst_4DBCommunication.MidlandModels;

public partial class MastUser
{
    public string? TxnId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Userroll { get; set; }
}
