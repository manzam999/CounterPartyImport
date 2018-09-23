using System.Collections.Generic;
using System.Linq;
using CounterPartyImport.Entities;
using CounterPartyImport.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CounterPartyImport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IRepositoryBase<Company> _companyRepository;
        private readonly ICompanyService _companyService;

        public CompanyController(IRepositoryBase<Company> companyRepository, ICompanyService companyService)
        {
            _companyRepository = companyRepository;
            _companyService = companyService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Company>> Get()
        {
            return Ok(_companyRepository.GetAll());
        }

        [HttpPost]
        [Route("Import")]
        public ActionResult Import()
        {
            var files = Request.Form.Files;

            if (files.Count == 0)
            {
                return BadRequest();
            }

            return Ok(_companyService.ImportCounterParties(files.First().OpenReadStream()));
        }
    }
}
