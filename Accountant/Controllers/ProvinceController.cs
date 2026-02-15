using Accountant.Context;
using Accountant.Domain.Entities;
using Accountant.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Accountant.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProvinceController: ControllerBase
    {
        private readonly ILogger<ProvinceController> _logger;
        private readonly MyDbContext _db;
        private readonly DbSet<Province> _provinces;
        public ProvinceController(ILogger<ProvinceController> logger, MyDbContext db)
        {
            _logger = logger;
            _db = db;
            _provinces = _db.Provinces;
        }

        [HttpPost]
        [Route("/Province/AddProvince")]
        public async Task<ActionResult<Province>> Create([FromBody]ProvinceDto dto)
        {
            var newProvince = new Province();
            newProvince.Name = dto.Name;
            newProvince.Capital = dto.Capital;

            await _provinces.AddAsync(newProvince);
            await _db.SaveChangesAsync();
            _logger.LogInformation("Province added!");

            return Created(null as Uri, newProvince);
        }

        // TODO: fill it
        //[HttpPut]
        //[Route("/Province/UpdateProvince")]
        //public async Task<IActionResult> UpdateAsync([FromBody] ProvinceUpdateDto dto)
        //{
        //TODO: fill it
        //}

        [HttpGet]
        [Route("/Province/GetAll")]
        public async Task<ActionResult<IEnumerable<Province>>> Get()
        {
            var province = await _provinces.Select(p => new
            {
                p.Id,
                p.Name,
                p.Capital,
                Profiles = p.Profiles.Select(pf=>pf.ProvinceId).ToArray()
            }).ToListAsync();
            return Ok(province);
        }
    }
}
