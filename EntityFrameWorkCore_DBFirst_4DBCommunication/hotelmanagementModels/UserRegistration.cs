using System;
using System.Collections.Generic;

namespace EntityFrameWorkCore_DBFirst_4DBCommunication.hotelmanagementModels;

public partial class UserRegistration
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? FullName { get; set; }

    public string? Password { get; set; }
}
