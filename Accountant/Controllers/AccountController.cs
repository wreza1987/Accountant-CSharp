using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Accountant.Context;
using Accountant.Domain.Entities;
using Accountant.Domain.Enums;
using Accountant.Dtos;

namespace Accountant.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly MyDbContext _db;
        private readonly DbSet<Account> _accounts;

        public AccountController(ILogger<AccountController> logger, MyDbContext db)
        {
            _logger = logger;
            _db = db;
            _accounts = _db.Accounts;
        }

        [HttpPost]
        [Route("/Account/Opening")]
        public async Task<ActionResult<Account>> Create([FromBody] AccountOpeningDto? dto)
        {
            if (dto == null)
            {
                return BadRequest("داده ورودی نامعتبر است.");
            }

            var newAccount = new Account();
            newAccount.ActiveMode = ActiveMode.Active;
            newAccount.SetAccountType(dto.AccountType);
            newAccount.SetAccountOpenedAt(dto.OpenedAt);

            await _accounts.AddAsync(newAccount);
            await _db.SaveChangesAsync();
            _logger.LogInformation("Account created successfully");

            return Created(null as Uri, newAccount);
        }

        [HttpPost]
        [Route("/Account/Closing")]
        public async Task<IActionResult> UpdateAsync(AccountClosingDto dto)
        {
            var selectedAccount = await _accounts.FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (selectedAccount == null)
                return NotFound();
            if (selectedAccount.ActiveMode == ActiveMode.Inactive)
                throw new Exception("این اکانت غیرفعال است!");
            selectedAccount.ActiveMode = ActiveMode.Inactive;
            selectedAccount.ClosedAt = dto.ClosedAt;
            _accounts.Update(selectedAccount);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}