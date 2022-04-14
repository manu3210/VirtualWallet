using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualWallet.DTO;
using VirtualWallet.Interfaces;
using VirtualWallet.Models;

namespace VirtualWallet.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        
        public async Task<IActionResult> Index()
        {
            return View(await GetAccountList());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _accountService.Get((int)id);
            if (account == null)
            {
                return NotFound();
            }

            return View(new AccountDto(account));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( AccountDto account)
        {
            if (ModelState.IsValid)
            {
                account.Balance = 0;
                account.UserId = (int)HttpContext.Session.GetInt32("user");
                await _accountService.Create(AccountDto.DtoToEntity(account));
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _accountService.Get((int)id);
            if (account == null)
            {
                return NotFound();
            }

            return View(new AccountDto(account));
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,Balance")] AccountDto account)
        {
            if (id != account.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                account.UserId = (int)HttpContext.Session.GetInt32("user");
                await _accountService.Update(id, AccountDto.DtoToEntity(account));
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _accountService.Get((int)id);
            if (account == null)
            {
                return NotFound();
            }

            return View(new AccountDto(account));
        }

        [HttpDelete, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _accountService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Transfer()
        {
            return View(await GetAccountList());
        }

        [HttpPut]
        public async Task<IActionResult> Transfer(int fromId, int toId, double amount)
        {
            string result = await _accountService.Transfer(fromId, toId, amount);

            return RedirectToAction("Result", "Accounts", new { msj = result });
        }

        public IActionResult Result(string msj)
        {
            ViewBag.msj = msj;
            return View();
        }

        public async Task<IActionResult> AddMoney()
        {
            return View(await GetAccountList());
        }

        [HttpPost]
        public async Task<IActionResult> AddMoney(int id, double amount, string cardNumber, int monthExp, int yearExp)
        {
            string result = await _accountService.AddMoney(id, amount, cardNumber, monthExp, yearExp);

            return RedirectToAction("Result", "Accounts", new { msj = result });
        }

        private async Task<List<AccountDto>> GetAccountList()
        {
            var list = new List<AccountDto>();

            foreach (Account account in await _accountService.GetAll())
            {
                if (HttpContext.Session.GetInt32("user") == account.UserId)
                {
                    list.Add(new AccountDto(account));
                }
            }

            return list;
        }
    }
}
