
using Microsoft.AspNetCore.Mvc;
using VKX_API01.Models;
using VKX_API01.Service;
using VKX_API01.Service.Dto.Company;

namespace VKX_API01.Controllers
{
    [Route("api/company")]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyService _companyService;
        public CompanyController(CompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _companyService.getAll());
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            return Ok(await _companyService.GetById(Id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CompanyCreateDto model)
        {
            return Ok(await _companyService.Create(model));
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, [FromBody]CompanyUpdateDto model)
        {
            return Ok(await _companyService.Update(Id,model));
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            return Ok(await _companyService.Delete(Id));
        }

    }
}
