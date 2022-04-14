using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualWallet.DTO;
using VirtualWallet.Interfaces;
using VirtualWallet.Models;

namespace VirtualWallet.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var list = new List<UserDto>();

            foreach (User user in await _userService.GetAll())
            {
                list.Add(new UserDto(user));
            }

            return View(list);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userService.Get((int)id);
            if (user == null)
            {
                return NotFound();
            }

            return View(new UserDto(user));
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View("SignIn");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn([Bind("Id,FirstName,LastName,DateOfBirth,Dni,Email,UserName,Password")] UserDto user)
        {
            if (ModelState.IsValid)
            {
                await _userService.Create(UserDto.DtoToEntity(user));
                return RedirectToAction("Index", "Home");
            }
            return View(user);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userService.Get((int)id);
            if (user == null)
            {
                return NotFound();
            }

            return View(new UserDto(user));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,DateOfBirth,Dni,Email,UserName,Password")] UserDto user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _userService.Update(id, UserDto.DtoToEntity(user));
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userService.Get((int)id);
            if (user == null)
            {
                return NotFound();
            }

            return View(new UserDto(user));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _userService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Login()
        {
            return View("LogIn");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (email != null && password != null)
            {
                var user = await _userService.GetForLogin(email, password);

                if (user != null)
                {
                    HttpContext.Session.SetInt32("user", user.Id);
                    return RedirectToAction("Index", "Accounts");
                }
            }

            return View();
        }

        
    }
}
