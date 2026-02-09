using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Accountant.Context;
using Accountant.Domain.Entities;


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
        public async Task<IActionResult> SaveAsync([FromBody] Profile dto)
        {
            var profile = await _db.Profiles.FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (profile == null) return NotFound();
            
            await _profiles.AddAsync(profile);
            await _db.SaveChangesAsync();
            _logger.LogInformation($"----- {dto.Name} Added -----");
            
            return Created(
                null as Uri, profile);
        }
    }
}
