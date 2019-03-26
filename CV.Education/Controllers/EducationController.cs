using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CV.Education.Controllers
{
    [Route("api/[controller]")]
    public class EducationController : Controller
    {
        // TODO: Ver DI
        EducationRepository repository = new EducationRepository();

        [HttpGet]
        public IEnumerable<Education> Get(bool? enabled)
        {
            return repository
                .GetEducation(enabled);
        }        
    }
}
