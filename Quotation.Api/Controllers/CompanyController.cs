using Microsoft.AspNetCore.Mvc;
using Quotation.Application.Interface.Service;
using Quotation.Domain.Entity;

namespace Quotation.Api.Controllers
{
    public class CompanyController(ICompanyService service) : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<Company>> Get(Guid uid)
        {
            var response = await service.Get(uid);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Save([FromBody] Company company)
        {
            var response = await service.Save(company);
            return Created();
        }
    }
}
