using System;
using System.Collections.Generic;
using System.Linq;
using CV.Education;
using Microsoft.EntityFrameworkCore;

public class EducationRepository
{
    // TODO: Ver DI
    CVContext context = new CVContext();

    public IEnumerable<Education> GetEducation(bool? enabled)
    {
        return context.Education
            .Where(e => !enabled.HasValue || e.Enabled == enabled)
            .ToList();
    }
}