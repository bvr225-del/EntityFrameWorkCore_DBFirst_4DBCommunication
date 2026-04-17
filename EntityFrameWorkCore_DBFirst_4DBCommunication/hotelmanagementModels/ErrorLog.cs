using System;
using System.Collections.Generic;

namespace EntityFrameWorkCore_DBFirst_4DBCommunication.hotelmanagementModels;

public partial class ErrorLog
{
    public int Id { get; set; }

    public string? CurrentUser { get; set; }

    public int? ErrorNumber { get; set; }

    public string? ErrorSeverity { get; set; }

    public string? ErrorState { get; set; }

    public string? ErrorProcedure { get; set; }

    public int? ErrorLine { get; set; }

    public string? ErrorMessage { get; set; }

    public string? Servername { get; set; }

    public DateTime? Errordtae { get; set; }
}
