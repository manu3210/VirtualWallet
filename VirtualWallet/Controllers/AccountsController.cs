using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        public IActionResult Index()
        {
            return View(GetAccountList());
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = _accountService.Get((int)id);
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
        public IActionResult Create([Bind("Name,Type")] AccountDto account)
        {
            if (ModelState.IsValid)
            {
                account.Balance = 0;
                account.UserId = (int)HttpContext.Session.GetInt32("user");
                _accountService.Create(AccountDto.DtoToEntity(account));
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = _accountService.Get((int)id);
            if (account == null)
            {
                return NotFound();
            }

            return View(new AccountDto(account));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Type,Balance")] AccountDto account)
        {
            if (id != account.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                account.UserId = (int)HttpContext.Session.GetInt32("user");
                _accountService.Update(id, AccountDto.DtoToEntity(account));
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = _accountService.Get((int)id);
            if (account == null)
            {
                return NotFound();
            }

            return View(new AccountDto(account));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _accountService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Transfer()
        {
            return View(GetAccountList());
        }

        [HttpPost]
        public IActionResult Transfer(int fromId, int toId, double amount)
        {
            string result = _accountService.Transfer(fromId, toId, amount);

            return RedirectToAction("Result", "Accounts", new { msj = result });
        }

        public IActionResult Result(string msj)
        {
            ViewBag.msj = msj;
            return View();
        }

        public IActionResult AddMoney()
        {
            return View(GetAccountList());
        }

        [HttpPost]
        public IActionResult AddMoney(int id, double amount, string cardNumber, int monthExp, int yearExp)
        {
            string result = _accountService.AddMoney(id, amount, cardNumber, monthExp, yearExp);

            return RedirectToAction("Result", "Accounts", new { msj = result });
        }

        private List<AccountDto> GetAccountList()
        {
            var list = new List<AccountDto>();

            foreach (Account account in _accountService.GetAll())
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
