using System;
using System.Collections.Generic;

namespace EntityFrameWorkCore_DBFirst_4DBCommunication.MidlandModels;

public partial class SurveyResult
{
    public string? UserSurveyId { get; set; }

    public string? Name { get; set; }

    public string? Timestamp { get; set; }

    public string? UserId { get; set; }
}
