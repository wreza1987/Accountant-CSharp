using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Accountant.Context;
using Accountant.Domain.Entities;
using Accountant.Dtos;


namespace Accountant.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController: ControllerBase
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

        [HttpGet]
        [Route("add-profile")]
        public async Task<IActionResult> SaveAsync([FromBody] ProfileDto dto)
        {
            var newProfile = new Profile
            {
                ProfileType = dto.ProfileType,
                Name = dto.Name,
                ProvinceId = dto.ProvinceId
            };

            await _profiles.AddAsync(newProfile);
            await _db.SaveChangesAsync();
            _logger.LogInformation($"----- {dto.Name} Added -----");
            
            return Created(
                null as Uri, newProfile);
        }
    }
}
