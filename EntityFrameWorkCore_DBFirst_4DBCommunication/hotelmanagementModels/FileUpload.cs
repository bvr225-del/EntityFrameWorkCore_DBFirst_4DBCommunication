using System;
using System.Collections.Generic;

namespace EntityFrameWorkCore_DBFirst_4DBCommunication.hotelmanagementModels;

public partial class FileUpload
{
    public int Id { get; set; }

    public string? FileName { get; set; }

    public string? FilePath { get; set; }

    public string? ModifiedFilename { get; set; }

    public string? Createdby { get; set; }

    public DateTime? CreatedDateTime { get; set; }
}
