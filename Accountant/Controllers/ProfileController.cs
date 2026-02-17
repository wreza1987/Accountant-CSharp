using Accountant.Context;
using Accountant.Domain.Entities;
using Accountant.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;


namespace Accountant.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly ILogger<ProfileController> _logger;
        private readonly MyDbContext _db;
        private readonly DbSet<Profile> _profiles;
        public ProfileController(ILogger<ProfileController> logger, MyDbContext db)
        {
            _logger = logger;
            _db = db;
            _profiles = _db.Profiles;
        }

        [HttpPost]
        [Route("/Profile/AddProfile")]
        public async Task<IActionResult> SaveAsync([FromBody] ProfileDto dto)
        {
            var newProfile = new Profile
            {
                ProfileType = dto.ProfileType,
                Name = dto.Name,
                ProvinceId = dto.ProvinceId,
                Province =  new Province
                {
                    Id = dto.ProvinceId,
                }
            };

            await _profiles.AddAsync(newProfile);
            await _db.SaveChangesAsync();
            _logger.LogInformation($"----- {dto.Name} Added -----");

            return Created(
                null as Uri, newProfile);
        }

        [HttpPut]
        [Route("/Profile/UpdateProfile")]
        public async Task<IActionResult> UpdateAsync([FromBody] ChangeProfileDto dto)
        {
            var selectedProfile = await _profiles.FirstOrDefaultAsync(x => x.Id == dto.Id);

            if (selectedProfile == null)
                return NotFound();
            selectedProfile.Name = dto.Name;
            selectedProfile.ProvinceId = dto.ProvinceId;
            _profiles.Update(selectedProfile);
            await _db.SaveChangesAsync();
            _logger.LogInformation($"----- {dto.Name} Updated -----");
            return Ok();
        }

        [HttpGet]
        [Route("/Profile/GetAll")]
        public async Task<ActionResult<IEnumerable<Profile>>> Get()
        {
            var account = await _profiles.Select(p => new
            {
                p.Id,
                p.ProfileType,
                p.Name,
                p.ProvinceId,
                p.ProfileAccounts,
            }).ToListAsync();
            return Ok(account);
        }
    }
}
