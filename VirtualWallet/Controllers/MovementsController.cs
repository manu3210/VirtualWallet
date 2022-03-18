using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VirtualWallet.DTO;
using VirtualWallet.Interfaces;
using VirtualWallet.Models;

namespace VirtualWallet.Controllers
{
    public class MovementsController : Controller
    {
        private readonly IMovementService _movementService;

        public MovementsController(IMovementService movementService)
        {
            _movementService = movementService;
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movements = _movementService.Get((int)id);
            if (movements == null)
            {
                return NotFound();
            }

            return View(new MovementDto(movements));
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movements = _movementService.Get((int)id);
            if (movements == null)
            {
                return NotFound();
            }

            return View(new MovementDto(movements));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, string remarks)
        {
            var movement = _movementService.Get(id);
            movement.remarks = remarks;

            _movementService.Update(id, movement);

            return RedirectToAction("Details", "Accounts", new { id = movement.AccountId });
        }
    }
}
