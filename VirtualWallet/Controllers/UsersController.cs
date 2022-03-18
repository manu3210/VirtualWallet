using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        public IActionResult Index()
        {
            var list = new List<UserDto>();

            foreach (User user in _userService.GetAll())
            {
                list.Add(new UserDto(user));
            }

            return View(list);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _userService.Get((int)id);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignIn([Bind("Id,FirstName,LastName,DateOfBirth,Dni,Email,UserName,Password")] UserDto user)
        {
            if (ModelState.IsValid)
            {
                _userService.Create(UserDto.DtoToEntity(user));
                return RedirectToAction("Index", "Home");
            }
            return View(user);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _userService.Get((int)id);
            if (user == null)
            {
                return NotFound();
            }

            return View(new UserDto(user));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,FirstName,LastName,DateOfBirth,Dni,Email,UserName,Password")] UserDto user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _userService.Update(id, UserDto.DtoToEntity(user));
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _userService.Get((int)id);
            if (user == null)
            {
                return NotFound();
            }

            return View(new UserDto(user));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _userService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Login()
        {
            return View("LogIn");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string email, string password)
        {
            if (email != null && password != null)
            {
                var user = _userService.GetForLogin(email, password);

                if (user != null)
                {
                    HttpContext.Session.SetInt32("user", user.Id);
                    return RedirectToAction("Index", "Accounts");
                }

            }

            return View();
        }

        public IActionResult SignIn()
        {
            return View("SignIn");
        }

    }
}
