using Accountant.Context;
using Accountant.Domain.Entities;
using Accountant.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Accountant.Controllers
{
    [ApiController]
    [Route("controller")]
    public class ProfileAccountController: ControllerBase
    {
        private readonly ILogger<ProfileAccountController> _logger;
        private readonly MyDbContext _db;
        private readonly DbSet<ProfileAccount> _profileAccounts;

        public ProfileAccountController(ILogger<ProfileAccountController> logger, MyDbContext db)
        {
            _logger = logger;
            _db = db;
            _profileAccounts = _db.ProfileAccounts;
        }

        [HttpPost]
        [Route("/ProfileAccount/Creating")]
        public async Task<ActionResult<ProfileAccount>> Create([FromBody] ProfileAccountDto dto)
        {
            var currentSum = await _db.ProfileAccounts
                .Where(pa => pa.AccountId == dto.AccountId)
                .SumAsync(pa => pa.ShareOwned);
            
            if (currentSum + dto.ShareOwned > 1)
                throw new InvalidOperationException("مجموع سهم‌ها بیش از ۱ می‌شود");
            
            var newProfileAccount = new ProfileAccount();
            
            newProfileAccount.ProfileId = dto.ProfileId;
            newProfileAccount.AccountId = dto.AccountId;
            
            newProfileAccount.ShareOwned = dto.ShareOwned;
            newProfileAccount.Profile.Id = dto.ProfileId;
            newProfileAccount.Account.Id = dto.AccountId;
            
            await _profileAccounts.AddAsync(newProfileAccount);
            await _db.SaveChangesAsync();
            _logger.LogInformation("Profile Account Created!");
            return Created(null as Uri, newProfileAccount);
        }
        //
        // [HttpPut]
        // [Route("/ProfileAccount/Updating")]
        // public async Task<IActionResult> UpdateAsync(ChangeProfileAccountDto dto)
        // {
        //     var selectedProfileAccount = await _profileAccounts.FirstOrDefaultAsync(x => x.Id == dto.Id);
        //     if (selectedProfileAccount != null) return NotFound();
        //     // TODO: check shareowned!
        //     selectedProfileAccount.ShareOwned = dto.ShareOwned;
        //
        //     _profileAccounts.Update(selectedProfileAccount);
        //     await _db.SaveChangesAsync();
        //     return Ok();
        // }

        [HttpGet]
        [Route("/ProfileAccount/GetAll")]
        public async Task<ActionResult<IEnumerable<ProfileAccount>>> Get()
        {
            var profileAccount = await _profileAccounts.Select(pa => new
            {
                pa.Id,
                pa.ProfileId,
                pa.AccountId,
                pa.ShareOwned,
            }).ToListAsync();
            return Ok(profileAccount);
        }
    }
}
